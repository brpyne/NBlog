using Rock.Framework.DirectoryServices;

namespace Fullback.WebHost.Auth
{
    public class User : TeamMemberBase
    {
        [DirectoryAttribute(ADProperty.UserName)]
        public string UserName { get; set; }

        [DirectoryAttribute(ADProperty.FirstName)]
        public string FirstName { get; set; }

        [DirectoryAttribute(ADProperty.LastName)]
        public string LastName { get; set; }

        [DirectoryAttribute(ADProperty.CommonId)]
        public new int CommonId { get; set; }

        [DirectoryAttribute(ADProperty.PictureUrl)]
        public string PictureURL { get; set; }

        [DirectoryAttribute(ADProperty.Phone)]
        public string Phone { get; set; }

        [DirectoryAttribute(ADProperty.CellPhone)]
        public string CellPhone { get; set; }

        //public UserPermission UserPermission { get; set; }
    }
}