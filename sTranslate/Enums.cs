using System;
using System.Configuration;

namespace sCore.Base
{
	public sealed class Enums
	{
        /// ---------------------------------------------------------------------------------------------
        /// Description for struct.
        /// ---------------------------------------------------------------------------------------------

        public struct FileStruct
        {
            public string Flags;
            public string Owner;
            public string Group;
            public bool IsDirectory;
            public string CreateTime;
            public string ParentDirectory;
            public string Name;
        }

        /// ---------------------------------------------------------------------------------------------
        /// Description for Enums.
        /// ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Insert placements 
        /// </summary>
        public enum InsertPlacements
        {
            Before = 1,
            After
        }
        public static InsertPlacements ToInsertPlacement(string value)
        {
            return (InsertPlacements)Enums.GetEnumState(typeof(InsertPlacements), value);
        }

        /// <summary>
        /// FileListStyle
        /// </summary>
        public enum FileListStyles
        {
            UnixStyle,
            WindowsStyle,
            Unknown
        }
        public static FileListStyles ToFileListStyle(string value)
        {
            return (FileListStyles)GetEnumState(typeof(FileListStyles), value);
        }


        /// <summary>
        /// Archive directory types
        /// </summary>
        public enum ArchiveDirectoryTypes
        {
            Archive = 0,
            Skip,
            Error
        }
        public static ArchiveDirectoryTypes ToArchiveDirectoryType(string value)
        {
            return (ArchiveDirectoryTypes)GetEnumState(typeof(ArchiveDirectoryTypes), value);
        }


        /// <summary>
        /// Debug view levels
        /// </summary>
        public enum DebugViewLevels
        {
            None = 0,
            All,
            Copy,
            Exclude
        }
        public static DebugViewLevels ToViewLevel(string value)
        {
            return (DebugViewLevels)GetEnumState(typeof(DebugViewLevels), value);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FilterTypes
        {
            Exclude = 0,
            Select
        }
        public static FilterTypes ToFilterType(string value)
        {
            return (FilterTypes)GetEnumState(typeof(FilterTypes), value);
        }

        /// <summary>
        /// Confiuration policys 
        /// </summary>
        public enum ConfigPolicys
        {
            Undefined = 0,
            File,
            Database
        }
        public static ConfigPolicys ToConfigPolicy(string value)
        {
            return (ConfigPolicys)GetEnumState(typeof(ConfigPolicys), value);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum AddinTypes
        {
            Undefined = 0,
            Agent,
            Guard
        }
        public static AddinTypes ToAddinType(string value)
        {
            return (AddinTypes)GetEnumState(typeof(AddinTypes), value);
        }

        /// <summary>
        /// Thread startup types
        /// </summary>
        public enum StartupTypes
        {
            Manual = 0,
            Automatic,
            Disabled
        }
        public static StartupTypes ToStartupType(string value)
        {
            return (StartupTypes)GetEnumState(typeof(StartupTypes), value);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum HexValueLength
        {
            TwoBytes = 2,
            TreeBytes = 3
        }
        public static HexValueLength ToHexValueLengt(string value)
        {
            return (HexValueLength)GetEnumState(typeof(HexValueLength), value);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum BitStates
        {
            Low = 0,
            High = 1
        }
        public static BitStates ToBitState(string value)
        {
            return (BitStates)GetEnumState(typeof(BitStates), value);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ByteOrderInDataWords
        {
            HighLow,
            LowHigh
        }
        public static ByteOrderInDataWords ToByteOrderInDataWord(string value)
        {
            return (ByteOrderInDataWords)GetEnumState(typeof(ByteOrderInDataWords), value);
        }


        /// <summary>
        /// 
        /// </summary>
        public enum MessageFormats
        {
            Fixed = 0,
            FieldSeparated,
            FixedByteArray,
            FieldSeparatedByteArray,
            Xml
        }
        public static MessageFormats ToMessageFormat(string value)
        {
            return (MessageFormats)GetEnumState(typeof(MessageFormats), value);
        }


        /// <summary>
        /// The state of a message
        /// </summary>
        public enum MessageStates
        {
            Disabled = 0,   // The message is disabled (Will not be handled at all)
            Created,        // The message is crested and not processed
            Processed,      // The message is processed successfully
            Delivered,      // The message is sent successfully to the receiver node (communication acknowledgment).
            Acknowledged,   // The message is acknowledged from the remote application (remote application acknowledgment).  
            Failed,         // The message processing is failed 
            Skipped         // The message prosessing is skipped
        }
        public static MessageStates ToMessageState(string value)
        {
            return (MessageStates)GetEnumState(typeof(MessageStates), value);
        }

        /// <summary>
        /// The states of a thread 
        /// </summary>
        public enum ProcessingStates
        {
            Initializing = 0,        
            Idle,           // The thread is in idel (wait) state.
            Processing,     // The thread is processing some task. 
            Shutdown        // The thread is in shutdown state.
        }
        public static ProcessingStates ToProcessingState(string value)
        {
            return (ProcessingStates)GetEnumState(typeof(ProcessingStates), value);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ObjectLoadStates
        {
            UnLoaded = 0,
            Loaded
        }
        public static ObjectLoadStates ToObjectLoadState(string value)
        {
            return (ObjectLoadStates)GetEnumState(typeof(ObjectLoadStates), value);
        }


        /// <summary>
        /// 
        /// </summary>
        public enum DriverRunStates
        {
            Normal = 0,
            SlowMotion
        }
        public static DriverRunStates ToDriverRunState(string value)
        {
            return (DriverRunStates)GetEnumState(typeof(DriverRunStates), value);
        }


        /// <summary>
        /// 
        /// </summary>
        public enum LogFilePolicies
        {
            Service = 0,
            Component
        }
        public static LogFilePolicies ToLogFilePolicy(string value)
        {
            return (LogFilePolicies)GetEnumState(typeof(LogFilePolicies), value);
        }


        /// <summary>
        /// 
        /// </summary>
        public enum SortOrders
        {
            Ascending = 0,
            Descending
        }
        public static SortOrders ToSortOrder(string value)
        {
            return (SortOrders)GetEnumState(typeof(SortOrders), value);
        }


        /// <summary>
        /// 
        /// </summary>
        public enum CleanActions
        {
            Copy = 0,
            Delete,
            Move,
        }
        public static CleanActions ToCleanAction(string value)
        {
            return (CleanActions)GetEnumState(typeof(CleanActions), value);
        }

        /// <summary>
        /// UserActions 
        /// </summary>
        public enum UserActions
        {
            Undefined = 0,
            Add,
            Change,
            Delete
        }
        public static UserActions ToUserAction(string value)
        {
            return (UserActions)GetEnumState(typeof(UserActions), value);
        }

        /// <summary>
        /// Options for Tool.Time() methode   
        /// </summary>
        public enum TimeOptions
        {
            Now = 0,
            LastDayOfThisMonth,
            FirstDayOfPreviousMonth
        }
        public static TimeOptions ToTimeOption(string value)
        {
            return (TimeOptions)GetEnumState(typeof(TimeOptions), value);
        }

 
        /// <summary>
        /// -----------------------------------------------------------------------------------------------------------------
        /// 
        /// Get enumeration state
        /// 
        /// -----------------------------------------------------------------------------------------------------------------
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Object GetEnumState(System.Type type, string value)
        {
            if (value == null || value == "")
                throw new Exception(string.Format("{0}:GetEnumState: Mandatory value parameter must be entered in call", type.ToString()));

            foreach (string s in Enum.GetNames(type))
            {
                if (value.ToLower() == s.ToLower())
                    return Convert.ChangeType(Enum.Parse(type, s), type);
            }

            throw new Exception(string.Format("{0}:GetEnumState: Enumeration don't contain value '{1}'", type.ToString(), value));
        }
    }
}
