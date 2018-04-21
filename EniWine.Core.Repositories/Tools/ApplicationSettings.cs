using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniWine.Core.Repositories.Tools
{
    public class ApplicationSettings
    {
        public static string NameAssemblyMappin
        {
            get
            {
                var value =
                    new System.Configuration.AppSettingsReader().GetValue("Chifon.Fluent.Mappins", typeof(string)).
                        ToString();

                if (string.IsNullOrEmpty(value))
                    throw new Exception("Assembly de mapeamento não definido");

                return value;
            }
        }

        public static string EmailSendFrom
        {
            get
            {
                var value = new System.Configuration.AppSettingsReader().GetValue("CHIFON.EMAILSENDTO", typeof(string)).ToString();

                if (string.IsNullOrEmpty(value))
                    return "desenvolvimento@chifon.com.br";

                return value;
            }
        }

        public static string[] EmailSendToCopy
        {
            get
            {
                string[] value = new System.Configuration.AppSettingsReader().GetValue("CHIFON.EMAILSENDTO.COPY", typeof(string)).ToString().Split(',');

                if (value.Count() == 0)
                    value[0] = "desenvolvimento@chifon.com.br";

                return value;
            }
        }

        public static string EmailSendToAlternative
        {
            get
            {
                var value = new System.Configuration.AppSettingsReader().GetValue("CHIFON.EMAILSENDTO.ALTERNATIVE", typeof(string)).ToString();

                if (string.IsNullOrEmpty(value))
                    return "desenvolvimento@chifon.com.br";

                return value;
            }
        }

        public static string SystemExecutionEnvironment
        {
            get
            {
                var value = new System.Configuration.AppSettingsReader().GetValue("CHIFON.AMBIENTE", typeof(string)).ToString();

                return string.IsNullOrEmpty(value) ? "D" : value;
            }
        }

        //public static string FolderFile
        //{
        //    get
        //    {
        //        return new System.Configuration.AppSettingsReader().GetValue("CHIFON.FILES.FOLDER", typeof(string)).ToString();
        //    }
        //}

        public static string FolderTemplates
        {
            get
            {
                return new System.Configuration.AppSettingsReader().GetValue("CHIFON.TEMPLATES.FOLDER", typeof(string)).ToString();
            }
        }

        public static string FolderPhotoFile
        {
            get
            {
                return new System.Configuration.AppSettingsReader().GetValue("CHIFON.FILES.FOLDERPHOTO", typeof(string)).ToString();
            }
        }

        public static string FolderPhotoVirtualDirectory
        {
            get
            {
                return new System.Configuration.AppSettingsReader().GetValue("CHIFON.FILES.VIRTUALDIRECTORYPHOTO", typeof(string)).ToString();
            }
        }

        public static string FolderVirtualXml
        {
            get
            {
                return new System.Configuration.AppSettingsReader().GetValue("CHIFON.FILES.FOLDERVIRTUALXML", typeof(string)).ToString();
            }
        }
        public static string FolderVirtualXls
        {
            get
            {
                return new System.Configuration.AppSettingsReader().GetValue("CHIFON.FILES.FOLDERVIRTUALXLS", typeof(string)).ToString();
            }
        }
    }
}
