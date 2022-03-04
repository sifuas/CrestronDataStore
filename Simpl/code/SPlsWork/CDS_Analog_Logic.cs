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

namespace UserModule_CDS_ANALOG_LOGIC
{
    public class UserModuleClass_CDS_ANALOG_LOGIC : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> SETVALUE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> DEFAULTVALUE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> TAG;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VALUE;
        ushort [] _VALUECACHE;
        CDSSimplWindows.CDSInterface CDSINTERFACE;
        private ushort ISVALIDTAG (  SplusExecutionContext __context__, CrestronString TAG ) 
            { 
            
            __context__.SourceCodeLine = 111;
            return (ushort)( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TAG ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt (TAG != " ") )) )) ; 
            
            }
            
        private void UPDATEPROPERTYVALUEFEEDBACK (  SplusExecutionContext __context__, ushort INDEX , ushort PROPERTYVALUE ) 
            { 
            
            __context__.SourceCodeLine = 116;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INDEX <= 100 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 118;
                
                __context__.SourceCodeLine = 120;
                _VALUECACHE [ INDEX] = (ushort) ( PROPERTYVALUE ) ; 
                __context__.SourceCodeLine = 121;
                VALUE [ INDEX]  .Value = (ushort) ( PROPERTYVALUE ) ; 
                } 
            
            
            }
            
        private void SAVEVALUETOCDS (  SplusExecutionContext __context__, CrestronString TAG , ushort INDEX , ushort VALUE ) 
            { 
            ushort ERROR = 0;
            
            
            __context__.SourceCodeLine = 129;
            try 
                { 
                __context__.SourceCodeLine = 131;
                
                __context__.SourceCodeLine = 133;
                CDSINTERFACE . SetLocalUintValue ( TAG .ToString(), (uint)( INDEX ), (uint)( VALUE )) ; 
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
                    
                    __context__.SourceCodeLine = 144;
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
                    
                    
                    __context__.SourceCodeLine = 156;
                    
                    __context__.SourceCodeLine = 158;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)100; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 160;
                        LOOKUPFAILED = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 162;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( IsSignalDefined( TAG[ INDEX ] ) ) && Functions.TestForTrue ( ISVALIDTAG( __context__ , TAG[ INDEX ] ) )) ) ) && Functions.TestForTrue ( IsSignalDefined( VALUE[ INDEX ] ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 164;
                            
                            __context__.SourceCodeLine = 166;
                            try 
                                { 
                                __context__.SourceCodeLine = 169;
                                PROPERTYVALUE = (ushort) ( CDSINTERFACE.GetLocalUintValue( TAG[ INDEX ] .ToString() ) ) ; 
                                } 
                            
                            catch (Exception __splus_exception__)
                                { 
                                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                                
                                __context__.SourceCodeLine = 174;
                                LOOKUPFAILED = (ushort) ( 1 ) ; 
                                
                                }
                                
                                __context__.SourceCodeLine = 178;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOOKUPFAILED == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 180;
                                    if ( Functions.TestForTrue  ( ( IsSignalDefined( DEFAULTVALUE[ INDEX ] ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 182;
                                        
                                        __context__.SourceCodeLine = 184;
                                        SAVEVALUETOCDS (  __context__ , TAG[ INDEX ], (ushort)( INDEX ), (ushort)( DEFAULTVALUE[ INDEX ] .UshortValue )) ; 
                                        __context__.SourceCodeLine = 185;
                                        UPDATEPROPERTYVALUEFEEDBACK (  __context__ , (ushort)( INDEX ), (ushort)( DEFAULTVALUE[ INDEX ] .UshortValue )) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 189;
                                        Print( "\r\nNo default value set for Tag {0}", TAG [ INDEX ] ) ; 
                                        } 
                                    
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 194;
                                    UPDATEPROPERTYVALUEFEEDBACK (  __context__ , (ushort)( INDEX ), (ushort)( PROPERTYVALUE )) ; 
                                    } 
                                
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 199;
                                Print( "\r\nInvalid Tag for propery at index {0:d}", (short)INDEX) ; 
                                } 
                            
                            __context__.SourceCodeLine = 158;
                            } 
                        
                        
                        
                    }
                    catch(Exception e) { ObjectCatchHandler(e); }
                    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                    return this;
                    
                }
                
            object SETVALUE_OnChange_1 ( Object __EventInfo__ )
            
                { 
                Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
                try
                {
                    SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                    ushort INDEX = 0;
                    
                    
                    __context__.SourceCodeLine = 207;
                    INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 209;
                    
                    __context__.SourceCodeLine = 212;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( IsSignalDefined( TAG[ INDEX ] ) ) && Functions.TestForTrue ( ISVALIDTAG( __context__ , TAG[ INDEX ] ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 215;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_VALUECACHE[ INDEX ] != SETVALUE[ INDEX ] .UshortValue))  ) ) 
                            { 
                            __context__.SourceCodeLine = 217;
                            SAVEVALUETOCDS (  __context__ , TAG[ INDEX ], (ushort)( INDEX ), (ushort)( SETVALUE[ INDEX ] .UshortValue )) ; 
                            } 
                        
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
                
                __context__.SourceCodeLine = 230;
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
            
            SETVALUE = new InOutArray<AnalogInput>( 100, this );
            for( uint i = 0; i < 100; i++ )
            {
                SETVALUE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( SETVALUE__AnalogSerialInput__ + i, SETVALUE__AnalogSerialInput__, this );
                m_AnalogInputList.Add( SETVALUE__AnalogSerialInput__ + i, SETVALUE[i+1] );
            }
            
            DEFAULTVALUE = new InOutArray<AnalogInput>( 100, this );
            for( uint i = 0; i < 100; i++ )
            {
                DEFAULTVALUE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( DEFAULTVALUE__AnalogSerialInput__ + i, DEFAULTVALUE__AnalogSerialInput__, this );
                m_AnalogInputList.Add( DEFAULTVALUE__AnalogSerialInput__ + i, DEFAULTVALUE[i+1] );
            }
            
            VALUE = new InOutArray<AnalogOutput>( 100, this );
            for( uint i = 0; i < 100; i++ )
            {
                VALUE[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VALUE__AnalogSerialOutput__ + i, this );
                m_AnalogOutputList.Add( VALUE__AnalogSerialOutput__ + i, VALUE[i+1] );
            }
            
            TAG = new InOutArray<StringInput>( 100, this );
            for( uint i = 0; i < 100; i++ )
            {
                TAG[i+1] = new Crestron.Logos.SplusObjects.StringInput( TAG__AnalogSerialInput__ + i, TAG__AnalogSerialInput__, 255, this );
                m_StringInputList.Add( TAG__AnalogSerialInput__ + i, TAG[i+1] );
            }
            
            
            INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
            for( uint i = 0; i < 100; i++ )
                SETVALUE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( SETVALUE_OnChange_1, false ) );
                
            
            _SplusNVRAM.PopulateCustomAttributeList( true );
            
            NVRAM = _SplusNVRAM;
            
        }
        
        public override void LogosSimplSharpInitialize()
        {
            CDSINTERFACE  = new CDSSimplWindows.CDSInterface();
            
            
        }
        
        public UserModuleClass_CDS_ANALOG_LOGIC ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
        
        
        
        
        const uint INITIALIZE__DigitalInput__ = 0;
        const uint SETVALUE__AnalogSerialInput__ = 0;
        const uint DEFAULTVALUE__AnalogSerialInput__ = 100;
        const uint TAG__AnalogSerialInput__ = 200;
        const uint VALUE__AnalogSerialOutput__ = 0;
        
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
