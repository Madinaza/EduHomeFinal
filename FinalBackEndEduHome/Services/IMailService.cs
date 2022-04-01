﻿using FinalBackEndEduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Services
{

    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
