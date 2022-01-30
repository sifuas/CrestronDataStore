namespace CDSSimplWindows;
        // class declarations
         class NoCDSDataFoundException;
         class CDSDataSetFailedException;
         class CDSInterface;
     class NoCDSDataFoundException 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Message[];
        STRING StackTrace[];
        STRING HelpLink[];
        STRING Source[];
        SIGNED_LONG_INTEGER HResult;
    };

     class CDSDataSetFailedException 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Message[];
        STRING StackTrace[];
        STRING HelpLink[];
        STRING Source[];
        SIGNED_LONG_INTEGER HResult;
    };

     class CDSInterface 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION SetLocalStringValue ( STRING tag , LONG_INTEGER index , STRING value );
        FUNCTION SetLocalUintValue ( STRING tag , LONG_INTEGER index , LONG_INTEGER value );
        FUNCTION SetLocalBoolValue ( STRING tag , LONG_INTEGER index , LONG_INTEGER value );
        STRING_FUNCTION GetLocalStringValue ( STRING tag );
        LONG_INTEGER_FUNCTION GetLocalUintValue ( STRING tag );
        LONG_INTEGER_FUNCTION GetLocalBoolValue ( STRING tag );
        FUNCTION SetGlobalStringValue ( STRING tag , LONG_INTEGER index , STRING value );
        FUNCTION SetGlobalUintValue ( STRING tag , LONG_INTEGER index , LONG_INTEGER value );
        FUNCTION SetGlobalBoolValue ( STRING tag , LONG_INTEGER index , LONG_INTEGER value );
        STRING_FUNCTION GetGlobalStringValue ( STRING tag );
        LONG_INTEGER_FUNCTION GetGlobalUintValue ( STRING tag );
        LONG_INTEGER_FUNCTION GetGlobalBoolValue ( STRING tag );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

