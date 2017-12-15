using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Bot.Services
{
  public class BotService
  {
    public TelegramBotClient Bot { get; set; }

    private readonly HashSet<long> _chatIds = new HashSet<long>();

    public BotService()
    {
    }

    public void Init(string apiKey)
    {
      Bot = new TelegramBotClient(apiKey);
      Bot.OnMessage += Bot_OnMessage;
      Bot.StartReceiving();
    }

    private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
    {
      _chatIds.Add(e.Message.Chat.Id);
      Bot.SendTextMessageAsync(e.Message.Chat.Id, "OK!");
    }

    public void Broadcast(string message)
    {
      foreach (var chatId in _chatIds)
      {
        Bot.SendTextMessageAsync(chatId, message);
      }
    }
  }
}
