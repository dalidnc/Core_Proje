using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SendMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = _writerMessageManager.TGetByID(id);
            return View(values);
        }
        
        public IActionResult AdminMessageDelete(int id)
        {
            var value = _writerMessageManager.TGetByID(id);
           _writerMessageManager.TDelete(value);
           if(value.Receiver=="admin@gmail.com")
            {
                return RedirectToAction("ReceiverMessageList");
            }
            else
            {
                return RedirectToAction("SendMessageList");
            }
           
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageManager.TAdd(p);
            return RedirectToAction("SendMessageList");
        }
    }
}
