using System;
using System.Collections.Generic;
using System.Text;

namespace SandBoxAppSelleniumTests
{
    public class Constants
    {
        public const string PROTOCOL = "https://";
        public const string BASEURL = PROTOCOL + "qa-sandbox.apps.htec.rs/";

        public const string LOGINPAGE = BASEURL + "login";
        public const string DASHBOARD = BASEURL + "dashboard";
        public const string CREATEPERSON = BASEURL + "create-person";
        public const string PEOPLE = BASEURL + "people";
        public const string CREATEPROJECT = BASEURL + "create-project";
        public const string PROJECTS = BASEURL + "projects";
        public const string CREATEROLE  = BASEURL + "create-role";
        public const string ROLES = BASEURL + "roles";
        public const string CREATESENIORITY = BASEURL + "create-seniority";
        public const string SENIORITIES = BASEURL + "seniorities";
        public const string CREATETECHNOLOGY = BASEURL + "create-technology";
        public const string TECHNOLOGIES = BASEURL + "technologies";
    }
}
