﻿using System.Globalization;

namespace MoneyMe_Loan_FrontEnd.DTOs
{
    public class ValidationMessageDto
    {
        public bool IsValid { get; set; }
        public List<string>? ValidationMessages { get; set; }
    }
}
