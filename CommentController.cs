using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        // GET: api/<controller>
        [HttpGet] //获取用户数量
        public ActionResult Get()
        {
            return Json(DAL.Comment.Instance.GetCount());
        }
        // GET api/<controller>/5
        [HttpPut("{id}")]   //获取单用户数据
        public ActionResult Get(int id)
        {

            return Json(DAL.Comment.Instance.GetWorkCount(id));
        }


        [HttpPost("page")]  //分页获取用户数据
        public ActionResult getPage([FromBody] Model.Page page)
        {
            var result = DAL.Comment.Instance.GetPage(page);
            if (result.Count() == 0)
                return Json(Result.Err("返回记录数为0"));
            else
                return Json(Result.Ok(result));
        }
        [HttpPost("workPage")]
        public ActionResult getWorkPage([FromBody] Model.CommentPage page)
        {
            var result = DAL.Comment.Instance.GetWorkPage(page);
            if (result.Count() == 0)
                return Json(Result.Err("返回记录数为0"));
            else
                return Json(Result.Ok(result));
        }

    }
}
