﻿using CreditTracker.Domain.Abstractions;
using CreditTracker.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Domain.Models
{
    public class User: Entity<string>
    {
        public string UserName { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public Role Role { get; private set; } = Role.Customer; // "Shop" or "Customer"
        public string Name { get; private set; } = default!;
        public string ICNoOrPassport { get; private set; } = default!;
        public string Address {  get; private set; } = default!;
        public string Latitude {  get; private set; } = default!;
        public string Longitude {  get; private set; } = default!;
        public string OtpCode { get; private set; } = default!;
        public DateTime OtpExpiry { get; private set; } = default!;
        public bool IsVerified { get; private set; } = default!;        

        public void SetOtp(string otp, DateTime expiry)
        {
            OtpCode = otp;
            OtpExpiry = expiry;
            IsVerified = false;
        }
        public bool VerifyOtp(string otp)
        {
            if (OtpCode == otp && OtpExpiry >= DateTime.UtcNow)
            {
                IsVerified = true;
                OtpCode = null;
                return true;
            }
            return false;
        }
        public static User Create( string userName, string email, string passwordHash, Role role, string name, string iCNoOrPassport, string address, string latitudel, string longitude)
        {
            var user = new User
            {
                UserName = userName ,
                Email = email ,
                PasswordHash = passwordHash ,
                Role = role ,
                Name = name ,
                ICNoOrPassport = iCNoOrPassport,
                Address = address ,
                Latitude = latitudel ,
                Longitude = longitude,
                IsActive = true
            };
            return user;
        }

        public void Update(string passwordHash, string name, string address, string latitude, string longitude)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            PasswordHash = passwordHash;
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;               
        }
        
    }
}
