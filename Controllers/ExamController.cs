using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineExam.Models;

namespace OnlineExam.Controllers
{
    public class ExamController : ApiController
    {
        [HttpGet]
        public IHttpActionResult onlineexam()
        {
            StudentManagementSystemEntities nd = new StudentManagementSystemEntities();
            IList<OnlineExamClass> oe = nd.onlineexams.Include("onlineexam").Select(x => new OnlineExamClass()
            {
                Qid = x.Qid,
                Question = x.Question,
                option1 = x.option1,
                option2 = x.option2,
                option3 = x.option3,
                option4 = x.option4,
                Corrections = x.Corrections
            }).ToList<OnlineExamClass>();
            return Ok(oe);
        }
    }
}
