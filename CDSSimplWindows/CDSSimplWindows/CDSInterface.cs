using System;
using System.Text;
using Crestron.SimplSharp;                          				// For Basic SIMPL# Classes
using Crestron.SimplSharp.CrestronDataStore;

namespace CDSSimplWindows
{

    public class NoCDSDataFoundException : Exception
    {
        public CrestronDataStore.CDS_ERROR Error;
        public NoCDSDataFoundException() { }
        public NoCDSDataFoundException(string msg, CrestronDataStore.CDS_ERROR error) : base(msg) { Error = error; }
    }

    public class CDSDataSetFailedException : Exception
    {
        public CrestronDataStore.CDS_ERROR Error;

        public CDSDataSetFailedException() { }
        public CDSDataSetFailedException( string msg, CrestronDataStore.CDS_ERROR error) :base( msg ) { Error = error; }

    }

    public class CDSInterface
    {

        /// <summary>
        /// SIMPL+ can only execute the default constructor. If you have variables that require initialization, please
        /// use an Initialize method
        /// </summary>
        public CDSInterface()
        {
            CrestronDataStoreStatic.InitCrestronDataStore();
        }

        /// <summary>
        /// Save a string to the local CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetLocalStringValue(string tag, uint index, string value)
        {
            var error = CrestronDataStoreStatic.SetLocalStringValue(tag, value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} setting local value {1} for tag {2}", error, value, tag);
                throw new CDSDataSetFailedException(String.Format("Error setting local value {0} for tag {1}", value, tag), error);
            }
        }

        /// <summary>
        /// Save a Uint to the local CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetLocalUintValue(string tag, uint index, uint value)
        {
            var error = CrestronDataStoreStatic.SetLocalUintValue(tag, value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} setting local value {1} for tag {2}", error, value, tag);
                throw new CDSDataSetFailedException( String.Format("Error setting local value {0} for tag {1}", value, tag ),error);
            }
        }

        /// <summary>
        /// Save a Uint as a bool to the local CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetLocalBoolValue(string tag, uint index, uint value)
        {
            var error = CrestronDataStoreStatic.SetLocalBoolValue(tag, ( value == 1 ) );

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} setting local value {1} for tag {2}", error, value, tag);
                throw new CDSDataSetFailedException(String.Format("Error setting local value {0} for tag {1}", value, tag), error);
            }
        }

        /// <summary>
        /// Save a string to the local CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetLocalStringValue(string tag)
        {
            string value;
            var error = CrestronDataStoreStatic.GetLocalStringValue(tag, out value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} getting local value for tag {1}", error, tag);
                throw new NoCDSDataFoundException(String.Format("No local data found for tag {0}", tag), error);
            }

            return value;
        }

        /// <summary>
        /// Save a Uint to the local CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public uint GetLocalUintValue(string tag)
        {
            uint value;
            var error = CrestronDataStoreStatic.GetLocalUintValue(tag, out value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} getting local value for tag {1}", error, tag);
                throw new NoCDSDataFoundException(String.Format("No local data found for tag {0}", tag), error);
            }

            return value;
        }

        /// <summary>
        /// Save a Uint as a bool to the local CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public uint GetLocalBoolValue(string tag)
        {
            bool value;
            var error = CrestronDataStoreStatic.GetLocalBoolValue(tag, out value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} getting local value for tag {1}", error, tag);
                throw new NoCDSDataFoundException(String.Format("No local data found for tag {0}", tag), error);
            }

            return (uint)(value ? 1 : 0);
        }

        /// <summary>
        /// Save a string to the Global CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetGlobalStringValue(string tag, uint index, string value)
        {
            var error = CrestronDataStoreStatic.SetGlobalStringValue(tag, value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} setting local value {1} for tag {2}", error, value, tag);
                throw new CDSDataSetFailedException(String.Format("Error setting global value {0} for tag {1}", value, tag), error);
            }
        }

        /// <summary>
        /// Save a Uint to the Global CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetGlobalUintValue(string tag, uint index, uint value)
        {
            var error = CrestronDataStoreStatic.SetGlobalUintValue(tag, value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} setting local value {1} for tag {2}", error, value, tag);
                throw new CDSDataSetFailedException(String.Format("Error setting global value {0} for tag {1}", value, tag), error);
            }
        }

        /// <summary>
        /// Save a Uint as a bool to the Global CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetGlobalBoolValue(string tag, uint index, uint value)
        {
            var error = CrestronDataStoreStatic.SetGlobalBoolValue(tag, (value == 1));

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} setting local value {1} for tag {2}", error, value, tag);
                throw new CDSDataSetFailedException(String.Format("Error setting global value {0} for tag {1}", value, tag), error);
            }
        }

        /// <summary>
        /// Save a string to the Global CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetGlobalStringValue(string tag)
        {
            string value;
            var error = CrestronDataStoreStatic.GetGlobalStringValue(tag, out value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} getting global value for tag {1}", error, tag);
                throw new NoCDSDataFoundException(String.Format("No global data found for tag {0}", tag), error);
            }

            return value;
        }

        /// <summary>
        /// Save a Uint to the Global CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public uint GetGlobalUintValue(string tag)
        {
            uint value;
            var error = CrestronDataStoreStatic.GetGlobalUintValue(tag, out value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} getting global value for tag {1}", error, tag);
                throw new NoCDSDataFoundException(String.Format("No global data found for tag {0}", tag), error);
            }

            return value;
        }

        /// <summary>
        /// Save a Uint as a bool to the Global CrestronDataStore
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public uint GetGlobalBoolValue(string tag)
        {            
            bool value;
            var error = CrestronDataStoreStatic.GetGlobalBoolValue(tag, out value);

            if (error != CrestronDataStore.CDS_ERROR.CDS_SUCCESS)
            {
                CrestronConsole.PrintLine("Error {0} getting global value for tag {1}", error, tag);
                throw new NoCDSDataFoundException(String.Format("No global data found for tag {0}", tag), error);
            }
            return (uint)(value ? 1 : 0);
        }
    }
}
