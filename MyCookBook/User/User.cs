using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Aggregates;
using mycookbook.cc.MyCookBook.User.Repository;
using mycookbook.cc.MyCookBook.User.Repository.Models;
using mycookbook.cc.MyCookBook.User.Views;

namespace mycookbook.cc.MyCookBook.User 
{
    [Table("Users")]
    public class User
    {
        private int? id;
        private EmailAddress emailAddress;
        private string name;
        private ProfilePicture profilePicture;
        private string blurb;

        public User(int? id, EmailAddress emailAddress, string name, ProfilePicture profilePicture, string blurb)
        {
            this.id = id;
            this.emailAddress = emailAddress;
            this.name = name;
            this.profilePicture = profilePicture;
            this.blurb = blurb;
        }

        public EmailAddress GetEmailAddress()
        {
            return this.emailAddress;
        }

        public UserApiView ApiView()
        {
            string profilePictureUrl = null;
            if (this.profilePicture != null) profilePictureUrl = this.profilePicture.GetUrl().ToString();
            return new UserApiView(this.id, this.emailAddress.ToString(), this.name, profilePictureUrl, "");
        }

        internal AuthenticationTicket AuthTicket()
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, this.id.ToString()),
                new Claim(ClaimTypes.Name, this.name),
            };
            var identity = new ClaimsIdentity(claims, "BasicAuthentication");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationTicket(principal, "BasicAuthentication");
        }

        internal UserModel DatabaseView()
        {
            UserModel userModel = new UserModel();
            userModel.Id = this.id;
            userModel.Email = this.emailAddress.ToString();
            userModel.Name = this.name;
            userModel.ProfilePicture = this.profilePicture == null ? null : this.profilePicture.GetFilename();
            userModel.Blurb = this.blurb;
            return userModel;
        }
    }
}