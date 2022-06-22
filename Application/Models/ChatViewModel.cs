using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ChatViewModel
    {
        public string SendUserID;
        public string userType;
        public string UserName;
    }

    public enum ChatUserType : int
	{
        None = 0,
        Student = 1,
        Teacher = 2,
        Methodist = 3
	}
}
