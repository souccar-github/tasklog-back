using TaskLog.Debugging;

namespace TaskLog
{
    public class TaskLogConsts
    {
        public const string LocalizationSourceName = "TaskLog";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "a7c316265a9648d2abf289cccfe7e561";
    }
}
