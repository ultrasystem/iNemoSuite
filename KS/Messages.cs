﻿namespace KS
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), CompilerGenerated]
    internal class Messages
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Messages()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static string KS_CAPTION_EDITOR
        {
            get
            {
                return ResourceManager.GetString("KS_CAPTION_EDITOR", resourceCulture);
            }
        }

        internal static string KS_CAPTION_SELECTOR
        {
            get
            {
                return ResourceManager.GetString("KS_CAPTION_SELECTOR", resourceCulture);
            }
        }

        internal static string KS_ERROR_ADD
        {
            get
            {
                return ResourceManager.GetString("KS_ERROR_ADD", resourceCulture);
            }
        }

        internal static string KS_ERROR_DELETE
        {
            get
            {
                return ResourceManager.GetString("KS_ERROR_DELETE", resourceCulture);
            }
        }

        internal static string KS_ERROR_LOAD
        {
            get
            {
                return ResourceManager.GetString("KS_ERROR_LOAD", resourceCulture);
            }
        }

        internal static string KS_ERROR_MODIFY
        {
            get
            {
                return ResourceManager.GetString("KS_ERROR_MODIFY", resourceCulture);
            }
        }

        internal static string KS_ERROR_SAVE
        {
            get
            {
                return ResourceManager.GetString("KS_ERROR_SAVE", resourceCulture);
            }
        }

        internal static string KS_ERROR_SUPPORT_URL
        {
            get
            {
                return ResourceManager.GetString("KS_ERROR_SUPPORT_URL", resourceCulture);
            }
        }

        internal static string KS_FILTER_DB
        {
            get
            {
                return ResourceManager.GetString("KS_FILTER_DB", resourceCulture);
            }
        }

        internal static string KS_FILTER_IMAGES
        {
            get
            {
                return ResourceManager.GetString("KS_FILTER_IMAGES", resourceCulture);
            }
        }

        internal static string KS_MASK_KIT_CODE
        {
            get
            {
                return ResourceManager.GetString("KS_MASK_KIT_CODE", resourceCulture);
            }
        }

        internal static string KS_QUESTION_DELETE
        {
            get
            {
                return ResourceManager.GetString("KS_QUESTION_DELETE", resourceCulture);
            }
        }

        internal static string KS_QUESTION_SAVE
        {
            get
            {
                return ResourceManager.GetString("KS_QUESTION_SAVE", resourceCulture);
            }
        }

        internal static string KS_URL_KIT_ROOT
        {
            get
            {
                return ResourceManager.GetString("KS_URL_KIT_ROOT", resourceCulture);
            }
        }

        internal static string KS_URL_ST
        {
            get
            {
                return ResourceManager.GetString("KS_URL_ST", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("KS.Messages", typeof(Messages).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }
    }
}

