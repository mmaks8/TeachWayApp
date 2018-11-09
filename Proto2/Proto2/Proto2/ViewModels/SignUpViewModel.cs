using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proto2.ViewModels
{
        public class LoginViewModel : ViewModelBase
        {
                string firstname;
		            public string FirstName {
			              get {
				                    return firstname;
			                  }
			              set {
			    	                firstname = value;
				                    this.Notify ("FirstName");
			                  }
		            }
                
                
                string lastname;
		            public string LastName {
			              get {
				                    return lastname;
			                  }
			              set {
			    	                lastname = value;
				                    this.Notify ("LastName");
			                  }
		            }
                
                
                string username;
		            public string UserName {
			              get {
				                    return username;
			                  }
			              set {
			    	                username = value;
				                    this.Notify ("UserName");
			                  }
		            }
                
		            string email;
		            public string Email {
			              get {
				                    return email;
			                  }
			              set {
			    	                email = value;
				                    this.Notify ("Email");
			                  }
		            }
                
                string password;
		            public string Password {
			              get {
				                     return password;
			              }
			               set {
				                     password = value;
				                     this.Notify ("Password");
			                   }
		            }
                
                string confirmpassword;
		            public string ConfirmPassword {
			              get {
				                     return confirmpassword;
			              }
			               set {
				                     confirmpassword = value;
				                     this.Notify ("ConfirmPassword");
			                   }
		            }
        }
}
