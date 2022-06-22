using Application.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ChatHub : Hub
    {
        private readonly DataManager dataManagerRef;
        private readonly AppDbContext appDbContextRef;
        private IHttpContextAccessor _httpContextAccessor;

        public ChatHub(DataManager dataManager, AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
		{
            dataManagerRef = dataManager;
            appDbContextRef = appDbContext;
            _httpContextAccessor = httpContextAccessor;
		}

        public override Task OnConnectedAsync()
        {
            ConnectedUser.Ids.Add(Context.User.Identity.Name);
            string userID = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var messages = dataManagerRef.MessageRepositoryRef.GetAllMessagesInUser(userID).ToList();
            for (int i = 0; i < messages.Count; i++)
            {
                Clients.User(userID).SendAsync("Send", messages[i].UserName, messages[i].MessageText);
            }
            return base.OnConnectedAsync();
        }
		public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedUser.Ids.Remove(Context.User.Identity.Name);
            return base.OnDisconnectedAsync(exception);
		}

        public async Task Send(string message, string userID)
        {
            if (userID == "-1")
                return;

            string sendedUserName = "";
            if (appDbContextRef.UniversityUser.First(x => x.Id == userID) != null)
                sendedUserName = appDbContextRef.UniversityUser.First(x => x.Id == userID).UserName;

            var currentUser = _httpContextAccessor.HttpContext?.User;
            if (ConnectedUser.Ids.Exists(x => x.Equals(sendedUserName))) 
            {
                await Clients.User(userID).SendAsync("Send", dataManagerRef.UniversityUserRepositoryRef.GetUserById(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value).ToString(), message);
                string array = "";
                for (int i = 0; i < ConnectedUser.Ids.Count; i++)
                {
                    array += ConnectedUser.Ids[i];
                }
            }
            else
            {
                dataManagerRef.MessageRepositoryRef.AddAndSaveMessage(new Domain.Entities.Message()
                {
                    UserName = dataManagerRef.UniversityUserRepositoryRef.GetUserById(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value).ToString(),
                    NameId = userID,
                    MessageText = message
                });
                string array = "";
				for (int i = 0; i < ConnectedUser.Ids.Count; i++)
				{
                    array += ConnectedUser.Ids[i];
				}
            }
        }

	}
}
