SELECT
	*
	--"typeID", "attributeID", "valueInt", "valueFloat", "dgmAttributeTypes"."displayName", "dgmAttributeTypes"."description", "unitID", "unitName"
FROM
	"dgmTypeAttributes"
	JOIN "dgmAttributeTypes" USING ("attributeID")
    JOIN "eveUnits" USING ("unitID")
WHERE
	"published" = TRUE
    AND
    --"typeID" = 440 -- '5MN Microwarpdrive II'
    --"typeID" = 1541 -- 'Power Diagnostic System II'
    --"typeID" = 1248 -- 'Capacitor Flux Coil II'
    --"typeID" = 1355 -- 'Reactor Control Unit II'
    --"typeID" = 33400 -- Bastion Module I
    --"typeID" = 3841 -- Large Shield Extender II
	--"typeID" = 2301 -- EM Ward Field II (********************)
	--"typeID" = 2281 -- Adaptive Invulnerability Field II (********************)
	--"typeID" = 2553 -- EM Ward Amplifier II (********************)
    --"typeID" = 1541 -- Power Diagnostic System II
    --"typeID" = 1256 -- Shield Flux Coil II
    --"typeID" = 20353 -- 1600mm Steel Plates II
	--"typeID" = 2048 -- Damage Control II
    --"typeID" = 4403 -- Reactive Armor Hardener
    --"typeID" = 11642 -- Armor EM Hardener II (********************)
    --"typeID" = 1319 -- Expanded Cargohold II
    --"typeID" = 1335 -- Reinforced Bulkheads II
    --"typeID" = 11239 -- Energized Armor Layering Membrane II
    --"typeID" = 1276 -- Layered Plating II
    --"typeID" = 11219 -- Energized EM Membrane II (********************)
    --"typeID" = 11269 -- Energized Adaptive Nano Membrane II (********************)
    --"typeID" = 1198 -- EM Plating II (********************)
    --"typeID" = 1306 -- Adaptive Nano Plating II (********************)
    --"typeID" = 30999 -- Medium Anti-EM Pump I (********************)
    --"typeID" = 31790 -- Medium Core Defense Field Extender I
    --"typeID" = 31055 -- Medium Trimark Armor Pump I
    --"typeID" = 33894 -- Medium Transverse Bulkhead I
    --"typeID" = 31718 -- Medium Anti-EM Screen Reinforcer I (********************)
    --"typeID" = 31119 -- Medium Cargohold Optimization I (********** EVERY RIG THAT HAS DRAWBACK TO SHIELD OR ARMOR **********)
    --"typeID" = 45586 -- 'Legion Defensive - Covert Reconfiguration'
    --"typeID" = 45596 -- 'Loki Defensive - Augmented Durability'
    "typeID" = 45592 -- 'Proteus Defensive - Covert Reconfiguration'
;