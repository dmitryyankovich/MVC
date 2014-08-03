using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class ShowTicketsViewModel : TicketViewModel
    {
        public int ToSort { get; set; }
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
    }
}