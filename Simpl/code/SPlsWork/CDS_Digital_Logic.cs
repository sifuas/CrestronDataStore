using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using CDSSimplWindows;

namespace UserModule_CDS_DIGITAL_LOGIC
{
    public class UserModuleClass_CDS_DIGITAL_LOGIC : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> TOGGLEVALUE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VALUEON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VALUEOFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DEFAULTVALUE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> TAG;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> VALUE;
        ushort [] _VALUECACHE;
        CDSSimplWindows.CDSInterface CDSINTERFACE;
        private ushort ISVALIDTAG (  SplusExecutionContext __context__, CrestronString TAG ) 
            { 
            
            __context__.SourceCodeLine = 95;
            return (ushort)( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TAG ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (TAG != " ") )) )) ; 
            
            }
            
        private void UPDATEPROPERTYVALUEFEEDBACK (  SplusExecutionContext __context__, ushort INDEX , ushort PROPERTYVALUE ) 
            { 
            
            __context__.SourceCodeLine = 100;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INDEX <= 100 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 102;
                
                __context__.SourceCodeLine = 104;
                _VALUECACHE [ INDEX] = (ushort) ( PROPERTYVALUE ) ; 
                __context__.SourceCodeLine = 105;
                VALUE [ INDEX]  .Value = (ushort) ( PROPERTYVALUE ) ; 
                } 
            
            
            }
            
        private void SAVEVALUETOCDS (  SplusExecutionContext __context__, CrestronString TAG , ushort INDEX , ushort VALUE ) 
            { 
            ushort ERROR = 0;
            
            
            __context__.SourceCodeLine = 113;
            try 
                { 
                __context__.SourceCodeLine = 115;
                
                __context__.SourceCodeLine = 117;
                CDSINTERFACE . SetLocalBoolValue ( TAG .ToString(), (uint)( INDEX ), (uint)( VALUE )) ; 
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                
                }
                
                
                }
                
            public void CDSVALUECHANGED ( object __sender__ /*CrestronString TAG */, ushort INDEX , ushort NEWVALUE ) 
                { 
                CrestronString  TAG  = (CrestronString )__sender__;
                try
                {
                    SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                    
                    __context__.SourceCodeLine = 128;
                    UPDATEPROPERTYVALUEFEEDBACK (  __context__ , (ushort)( INDEX ), (ushort)( NEWVALUE )) ; 
                    
                    
                }
                finally { ObjectFinallyHandler(); }
                }
                
            object INITIALIZE_OnPush_0 ( Object __EventInfo__ )
            
                { 
                Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
                try
                {
                    SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                    ushort INDEX = 0;
                    ushort ERROR = 0;
                    ushort LOOKUPFAILED = 0;
                    
                    ushort PROPERTYVALUE = 0;
                    
                    
                    __context__.SourceCodeLine = 140;
                    
                    __context__.SourceCodeLine = 142;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)100; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 144;
                        LOOKUPFAILED = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 146;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( IsSignalDefined( TAG[ INDEX ] ) ) && Functions.TestForTrue ( ISVALIDTAG( __context__ , TAG[ INDEX ] ) )) ) ) && Functions.TestForTrue ( IsSignalDefined( VALUE[ INDEX ] ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 148;
                            
                            __context__.SourceCodeLine = 150;
                            try 
                                { 
                                __context__.SourceCodeLine = 152;
                                PROPERTYVALUE = (ushort) ( CDSINTERFACE.GetLocalBoolValue( TAG[ INDEX ] .ToString() ) ) ; 
                                } 
                            
                            catch (Exception __splus_exception__)
                                { 
                                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                                
                                __context__.SourceCodeLine = 157;
                                LOOKUPFAILED = (ushort) ( 1 ) ; 
                                
                                }
                                
                                __context__.SourceCodeLine = 161;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOOKUPFAILED == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 163;
                                    if ( Functions.TestForTrue  ( ( IsSignalDefined( DEFAULTVALUE[ INDEX ] ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 165;
                                        
                                        __context__.SourceCodeLine = 167;
                                        SAVEVALUETOCDS (  __context__ , TAG[ INDEX ], (ushort)( INDEX ), (ushort)( DEFAULTVALUE[ INDEX ] .Value )) ; 
                                        __context__.SourceCodeLine = 168;
                                        UPDATEPROPERTYVALUEFEEDBACK (  __context__ , (ushort)( INDEX ), (ushort)( DEFAULTVALUE[ INDEX ] .Value )) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 172;
                                        Print( "\r\nNo default value set for Tag {0}", TAG [ INDEX ] ) ; 
                                        } 
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 177;
                                    UPDATEPROPERTYVALUEFEEDBACK (  __context__ , (ushort)( INDEX ), (ushort)( PROPERTYVALUE )) ; 
                                    } 
                                
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 182;
                                Print( "\r\nInvalid Tag for propery at index {0:d}", (short)INDEX) ; 
                                } 
                            
                            __context__.SourceCodeLine = 142;
                            } 
                        
                        
                        
                    }
                    catch(Exception e) { ObjectCatchHandler(e); }
                    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                    return this;
                    
                }
                
            object TOGGLEVALUE_OnPush_1 ( Object __EventInfo__ )
            
                { 
                Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
                try
                {
                    SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                    ushort INDEX = 0;
                    
                    
                    __context__.SourceCodeLine = 190;
                    INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 192;
                    
                    __context__.SourceCodeLine = 195;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IsSignalDefined( TAG[ INDEX ] ) ) && Functions.TestForTrue ( ISVALIDTAG( __context__ , TAG[ INDEX ] ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 197;
                        _VALUECACHE [ INDEX] = (ushort) ( Functions.Not( _VALUECACHE[ INDEX ] ) ) ; 
                        __context__.SourceCodeLine = 198;
                        SAVEVALUETOCDS (  __context__ , TAG[ INDEX ], (ushort)( INDEX ), (ushort)( _VALUECACHE[ INDEX ] )) ; 
                        __context__.SourceCodeLine = 199;
                        UPDATEPROPERTYVALUEFEEDBACK (  __context__ , (ushort)( INDEX ), (ushort)( _VALUECACHE[ INDEX ] )) ; 
                        } 
                    
                    
                    
                }
                catch(Exception e) { ObjectCatchHandler(e); }
                finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                return this;
                
            }
            
        object VALUEON_OnPush_2 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort INDEX = 0;
                
                
                __context__.SourceCodeLine = 206;
                INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 208;
                
                __context__.SourceCodeLine = 211;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IsSignalDefined( TAG[ INDEX ] ) ) && Functions.TestForTrue ( ISVALIDTAG( __context__ , TAG[ INDEX ] ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 213;
                    _VALUECACHE [ INDEX] = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 214;
                    SAVEVALUETOCDS (  __context__ , TAG[ INDEX ], (ushort)( INDEX ), (ushort)( _VALUECACHE[ INDEX ] )) ; 
                    __context__.SourceCodeLine = 215;
                    UPDATEPROPERTYVALUEFEEDBACK (  __context__ , (ushort)( INDEX ), (ushort)( _VALUECACHE[ INDEX ] )) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object VALUEOFF_OnPush_3 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort INDEX = 0;
            
            
            __context__.SourceCodeLine = 222;
            INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 224;
            
            __context__.SourceCodeLine = 227;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IsSignalDefined( TAG[ INDEX ] ) ) && Functions.TestForTrue ( ISVALIDTAG( __context__ , TAG[ INDEX ] ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 229;
                _VALUECACHE [ INDEX] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 230;
                SAVEVALUETOCDS (  __context__ , TAG[ INDEX ], (ushort)( INDEX ), (ushort)( _VALUECACHE[ INDEX ] )) ; 
                __context__.SourceCodeLine = 231;
                UPDATEPROPERTYVALUEFEEDBACK (  __context__ , (ushort)( INDEX ), (ushort)( _VALUECACHE[ INDEX ] )) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 243;
        Functions.SetArray (  ref _VALUECACHE , (ushort)0) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    _VALUECACHE  = new ushort[ 101 ];
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    TOGGLEVALUE = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        TOGGLEVALUE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( TOGGLEVALUE__DigitalInput__ + i, TOGGLEVALUE__DigitalInput__, this );
        m_DigitalInputList.Add( TOGGLEVALUE__DigitalInput__ + i, TOGGLEVALUE[i+1] );
    }
    
    VALUEON = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        VALUEON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VALUEON__DigitalInput__ + i, VALUEON__DigitalInput__, this );
        m_DigitalInputList.Add( VALUEON__DigitalInput__ + i, VALUEON[i+1] );
    }
    
    VALUEOFF = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        VALUEOFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VALUEOFF__DigitalInput__ + i, VALUEOFF__DigitalInput__, this );
        m_DigitalInputList.Add( VALUEOFF__DigitalInput__ + i, VALUEOFF[i+1] );
    }
    
    DEFAULTVALUE = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        DEFAULTVALUE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DEFAULTVALUE__DigitalInput__ + i, DEFAULTVALUE__DigitalInput__, this );
        m_DigitalInputList.Add( DEFAULTVALUE__DigitalInput__ + i, DEFAULTVALUE[i+1] );
    }
    
    VALUE = new InOutArray<DigitalOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        VALUE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( VALUE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( VALUE__DigitalOutput__ + i, VALUE[i+1] );
    }
    
    TAG = new InOutArray<StringInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        TAG[i+1] = new Crestron.Logos.SplusObjects.StringInput( TAG__AnalogSerialInput__ + i, TAG__AnalogSerialInput__, 255, this );
        m_StringInputList.Add( TAG__AnalogSerialInput__ + i, TAG[i+1] );
    }
    
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    for( uint i = 0; i < 100; i++ )
        TOGGLEVALUE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( TOGGLEVALUE_OnPush_1, false ) );
        
    for( uint i = 0; i < 100; i++ )
        VALUEON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( VALUEON_OnPush_2, false ) );
        
    for( uint i = 0; i < 100; i++ )
        VALUEOFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( VALUEOFF_OnPush_3, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    CDSINTERFACE  = new CDSSimplWindows.CDSInterface();
    
    
}

public UserModuleClass_CDS_DIGITAL_LOGIC ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint TOGGLEVALUE__DigitalInput__ = 1;
const uint VALUEON__DigitalInput__ = 101;
const uint VALUEOFF__DigitalInput__ = 201;
const uint DEFAULTVALUE__DigitalInput__ = 301;
const uint TAG__AnalogSerialInput__ = 0;
const uint VALUE__DigitalOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
