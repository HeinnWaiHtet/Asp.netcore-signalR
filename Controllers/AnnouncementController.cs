using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Asp.netCoreSignlaR.Hubs;

namespace Asp.netCoreSignlaR.Controllers
{
    public class AnnouncementController : Controller
    {
        #region Properties

        private readonly IHubContext<MessageHubs> hubContext;
        #endregion

        #region constructor

        public AnnouncementController(IHubContext<MessageHubs> hubContext)
        {
            this.hubContext = hubContext;
        }

        #endregion

        #region MessageSend

        /// <summary>
        /// Announcement View
        /// </summary>
        /// <returns></returns>
        [HttpGet("/announcement")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Send Message Using MessageHubs
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost("/announcement")]
        public async Task<IActionResult> Post([FromForm] string message)
        {
            await hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            return RedirectToAction("Index");
        }

        #endregion

    }
}
