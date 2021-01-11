using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneralSamples
{
    class MyEnum
    {
        public static void TestEnumParse()
        {
            PublisherAuthInfo authInfo = new PublisherAuthInfo();
            authInfo.AuthType = (PublisherAuthType)Enum.Parse(typeof(PublisherAuthType), "Dmsi");
            authInfo.HomeStsUrl = "https://uscentraleuap-dsts.dsts.core.windows.net/v2/wstrust/13/certificate";
            authInfo.MsiName = "nrptornmcall";
            authInfo.CertificateSubjectName = "";

            Console.WriteLine($"Auth information: {authInfo.ToString()}");
        }
    }

    public class PublisherAuthInfo
    {
        /// <summary>
        /// Gets or sets PublisherAuthType 
        /// </summary>
        public PublisherAuthType AuthType { get; set; }

        /// <summary>
        /// Gets or sets Home Sts Url 
        /// This is required if AuthType is not None
        /// </summary>
        public string HomeStsUrl { get; set; }

        /// <summary>
        /// Gets or sets Msi Name
        /// Required for dmsi auth
        /// </summary>
        public string MsiName { get; set; }

        /// <summary>
        /// Gets or sets Publisher Certificate Subject name for cert/default auth
        /// </summary>
        public string CertificateSubjectName { get; set; }

        public override string ToString()
        {
            return $"AuthType:{AuthType.ToString()}, HomeStsUrl:{HomeStsUrl}, MsiName:{MsiName}, CertificateSubjectName:{CertificateSubjectName}";
        }
    }

    public enum PublisherAuthType
    {
        /// <summary>
        /// Not set by user
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Certificate based auth
        /// </summary>
        Certificate = 1,

        /// <summary>
        /// Dmsi based auth
        /// </summary>
        Dmsi = 2,

        /// <summary>
        /// No Auth.
        /// </summary>
        NoAuth = 9999
    }
}