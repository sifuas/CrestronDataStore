# CrestronDataStore
Simpl modules that interface with the CrestronDataStore built in database

The CrestronDataStore is a built in database on the control processor to store Serial, Analog and Digital data. The CrestronDataStore provides both a Local store ( accessible only to the current program ) and a Global store ( accessible to any of the running programs on the control system ).

- ** Text Console Commands **
  - DATASTORESTATUS - run to show an overview of the datastore including # of records in local vs global datastore.
  - DATASTOREEXPORT - run to view in the console or save to a file ( XML format ) all of the current values in the datastore.
  - DATASTOREIMPORT - run to import an XML file from another system into the datastore.
  - DATASTOREDELETE - run to delete records from the datastore. Can specifiy local vs global, records older than X days, or all records.

The provided c# solution provides functions to integrate with both the Local and Global datastore using the CrestronDataStoreStatic class. The Simpl files currently only contain the Simpl+ interfaces to
the Local CrestronDataStore.

- **CDS Serial Logic.usp**

  - Provides the interface to save and recall serial values based on a Tag using the CrestronDataStore.
  
    - Inputs : Up to 100 serials can be initialized, stored and recalled using this module.
      - Initialize : When pulsed the module will loop through all of the inputs. If the Tag input is defined and the Tag is not empty "", then
        - If the tag does not exist the default value will be saved if a default value signal is defined on the symbol.
        - If the tag does exist the stored value will be assigned to the corresponding output if its signal is defined on the symbol.
      - SetValue[X] : Stores the serial value in the CrestronDataStore by looking up the Tag assigned to the same index X.
      - Tag[X] : The tag to associate with the data stored at index X.
      - DefaultValue[X] : The value that will be stored in the CrestronDataStore if there is not already a value stored there for the Tag associated with index X. This should only be saved on the first load of the program or if the user deletes the data store from the Text Console.
    - Outputs
      - Value[X] : The value stored in the CrestronDataStore. This will be the default value the first time the module is initialized.

- **CDS Analog Logic.usp**

  - Provides the interface to save and recall analog values based on a Tag using the CrestronDataStore.
  
    - Inputs : Up to 100 analogs can be initialized, stored and recalled using this module.
      - Initialize : When pulsed the module will loop through all of the inputs. If the Tag input is defined and the Tag is not empty "", then
        - If the tag does not exist the default value will be saved if a default value signal is defined on the symbol.
        - If the tag does exist the stored value will be assigned to the corresponding output if its signal is defined on the symbol.
      - SetValue[X] : Stores the analog value in the CrestronDataStore by looking up the Tag assigned to the same index X.
      - DefaultValue[X] : The value that will be stored in the CrestronDataStore if there is not already a value stored there for the Tag associated with index X. This should only be saved on the first load of the program or if the user deletes the data store from the Text Console.
      - Tag[X] : The tag to associate with the data stored at index X.
      
    - Outputs
      - Value[X] : The value stored in the CrestronDataStore. This will be the default value the first time the module is initialized.

- **CDS Digital Logic.usp**

  - Provides the interface to save and recall digital values based on a Tag using the CrestronDataStore.
  
    - Inputs : Up to 100 digitals can be initialized, stored and recalled using this module.
      - Initialize : When pulsed the module will loop through all of the inputs. If the Tag input is defined and the Tag is not empty "", then
        - If the tag does not exist the default value will be saved if a default value signal is defined on the symbol.
        - If the tag does exist the stored value will be assigned to the corresponding output if its signal is defined on the symbol.
      - ToggleValue[X] : Toggle the digital value assigned to index X of the module and store the new value to the CrestronDataStore.
      - ValueOn[X] : Set High the digital value assigned to index X of the module and store the new value to the CrestronDataStore.
      - ValueOff[X] : Set Low the digital value assigned to index X of the module and store the new value to the CrestronDataStore.
      - DefaultValue[X] : The value that will be stored in the CrestronDataStore if there is not already a value stored there for the Tag associated with index X. This should only be saved on the first load of the program or if the user deletes the data store from the Text Console.
      - Tag[X] : The tag to associate with the data stored at index X.
      
    - Outputs
      - Value[X] : The value stored in the CrestronDataStore. This will be the default value the first time the module is initialized.


