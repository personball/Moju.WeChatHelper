using System.Collections.Specialized;
using System.Configuration;
using System.Web.Mvc;

namespace Moju.WeChatHelper
{
    public class WeChatVerifyAttribute : ActionFilterAttribute
    {
        private static WeChatHelperSection config = (WeChatHelperSection)ConfigurationManager.GetSection("WeChatHelperSection");
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            NameValueCollection nvc = filterContext.HttpContext.Request.QueryString;
            if (!string.IsNullOrWhiteSpace(nvc["timestamp"]) &&
                !string.IsNullOrWhiteSpace(nvc["nonce"]) &&
                !string.IsNullOrWhiteSpace(nvc["signature"]))
            {
                //参数具备，进行验证
                string signature = nvc["signature"];//微信签名
                string Token = config.Token;//约定的标记
                if (Utils.WeChatRequestVerify(Token, nvc["timestamp"], nvc["nonce"],signature))
                {
                    //验证通过
                }
                else
                {
                    filterContext.Result = new HttpStatusCodeResult(401, "未授权，禁止调用！");//或403
                }
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(401, "未授权，禁止调用！");//或403
            }
        }
    }
}
