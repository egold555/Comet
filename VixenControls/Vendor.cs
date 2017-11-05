using VixenPlusCommon.Properties;

namespace VixenPlusCommon {
    public static class Vendor {
        public const int MinimumEventPeriod = 10;

        public static readonly string ProductDescription = Resources.ProductDescription;
        public const string ProductName = "Comet";
        public const string ProductURL = "http://golde.org/";
        public const string All = "*";
        public const string SeqFileIO = "SeqIOHelpers";
        
        public const string ModuleAuthoring = "Artisan";
        //public const string ModulePreview = "Rehersal";
        public const string ModuleManager = "Roadie";
        //public const string ModuleScheduler = "Conductor";

        public const string AppExtension = ".dll";
        //public const string DataExtension = ".vda";
        public const string DeletedExtension = ".x";
        public const string CsvExtension = ".csv";
        public const string GroupExtension = ".vpx";
        public const string MapperExtension = ".vmap";
        public const string NutcrakerModelExtension = ".nmx";
        public const string ProfileExtension = ".pro";
        //public const string ProgramExtension = ".vpr";
        public const string RoutineExtension = ".vir";
        public const string SequenceExtension = ".vix";
        public const string TemplateExtension = ".vpt";
        public const string UpdateFileExtension = ".7z";

        public const string SupportURL = "http://supporturlgoeshere.com/";

        public const string UpdateURL = "http://updateurlgoeshere.com/";
        public const string UpdateFile = "version.php";
        public const string UpdateReleaseNote = "ReleaseNotes.txt";
        public const string UpdateFileURL = UpdateURL + "Release";
        // ReSharper disable InconsistentNaming
        public const string UpdateSupport7zrProtected = "_7zr.exe";
        public const string UpdateSupport7zrReal = "7zr.exe";
        // ReSharper restore InconsistentNaming
        public const string UpdateSupportBatchProtected = "_update.bat";
        public const string UpdateSupportBatchReal = "update.bat";
    }
}