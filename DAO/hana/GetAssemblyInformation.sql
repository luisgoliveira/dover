﻿SELECT "Code", "U_Name" AS "Name", IFNULL("U_Description", "U_Name") AS "Description", "U_FileName" AS "FileName", 
    "U_Version" AS "Version", U_MD5 AS "MD5", "U_Date" AS "Date", "U_Size" AS "Size", "U_Type" AS "Type" 
FROM "@DOVER_MODULES" 
WHERE "U_Type" = '{1}' AND "U_Name" = '{0}'