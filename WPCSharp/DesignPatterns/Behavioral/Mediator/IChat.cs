﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPCSharp.DesignPatterns.Behavioral.Mediator
{
    public interface IChat
    {
        void Join(ChatMember chatMember);
        void Quit(ChatMember chatMember);
        void Send(string from, string to, string message);
        void Send(string from, string message);
    }
}
