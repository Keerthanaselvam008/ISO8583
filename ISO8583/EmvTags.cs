using ISO;
using System;
using System.Collections.Generic;
using System.IO;

class TLV
{
    public string Name { get; set; }
    public string Id { get; set; }
    public int Length { get; set; }
    //public int minLen { get; set; }
    //public int maxLen { get; set; }
    public string TagIdSecondHalf { get; set; }

    public bool orLength { get; set; }
    public string Value { get; set; }
    public TagLengthType TagLengthRepresentation { get; set; }
}
public enum TagLengthType
{
    Fixed,
    L,
    LL,
    LLL
}


class EmvTags
{
    public static void Emv()
    {
        string filePath = "emv_tags.txt"; // Update with your file path
        try
        {
            string emvData = File.ReadAllText(filePath);

            List<TLV> emvTags = new List<TLV>
            {
                //Already having 
                new TLV { Id = "9F06", Name = "Application Identifier (AID)", TagLengthRepresentation = TagLengthType.L | TagLengthType.LL },
                new TLV { Id = "5F34", Name = "Application Primary Account Number (PAN) Sequence Number",TagLengthRepresentation=TagLengthType.Fixed},
                new TLV { Id = "9F27", Name = "Cryptogram Information Data",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F26", Name = "Application Cryptogram" ,TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F10", Name = "Issuer Application Data",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL },
                new TLV { Id = "9F36", Name = "Application Transaction Counter (ATC)",TagLengthRepresentation=TagLengthType.Fixed},
                new TLV { Id = "9F02", Name = "Amount, Authorized (Numeric)",TagLengthRepresentation=TagLengthType.Fixed},
                new TLV { Id = "9F03", Name = "Amount, Other (Numeric)",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F1A", Name = "Terminal Country Code" , TagLengthRepresentation=TagLengthType.Fixed},
                new TLV { Id = "5F2A", Name = "Transaction Currency Code",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F37", Name = "Unpredictable Number",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F33", Name = "Terminal Capabilities",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F1E", Name = "Interface Device (IFD) Serial Number",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "57", Name = "Track 2 Data", TagLengthRepresentation = TagLengthType.L | TagLengthType.LL},
                new TLV { Id = "5A", Name = "Application PAN",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL},
                new TLV { Id = "82", Name = "Application Interchange Profile",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "8C", Name = "Card Risk Management Data",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                new TLV { Id = "95", Name = "Terminal Verification Results (TVR)" ,TagLengthRepresentation=TagLengthType.Fixed},
                new TLV { Id = "9A", Name = "Transaction Date",TagLengthRepresentation=TagLengthType.Fixed},
                new TLV { Id = "9C", Name = "Transaction Type",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9B", Name = "Transaction Status Information",TagLengthRepresentation=TagLengthType.Fixed},
                new TLV { Id = "50", Name = "Application Label",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL},
               
                //Keer
                new TLV { Id = "5F57", Name = "Account Type",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F01", Name = "Acquirer Identifier",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F40", Name = "Additional Terminal Capabilities",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "81", Name = "Amount, Authorised (Binary)",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F02", Name = "Amount, Authorised (Numeric)",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "4F", Name = "Application Dedicated File(ADF) Name",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL},
                new TLV { Id = "50", Name = "Application Label",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL},
                new TLV { Id = "9F12", Name = "Application Preferred Name",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL},
                new TLV { Id = "9F0A", Name = "Application Selection Registered Proprietary Data (ASRPD)",Length=0 },//var
                new TLV { Id = "61", Name = "Application Template",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                new TLV { Id = "9F07", Name = "Application Usage Control",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F08", Name = "Application Version Number",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "9F09", Name = "Application Version Number",TagLengthRepresentation=TagLengthType.Fixed },
                new TLV { Id = "89", Name = "Authorisation Code",TagLengthRepresentation=TagLengthType.Fixed},
                  new TLV { Id = "90", Name = "Biometric Solution ID",Length=0},//->Edit for VAR
                  new TLV { Id = "82", Name ="Biometric Subtype",TagLengthRepresentation = TagLengthType.Fixed},
                  new TLV { Id = "9F30", Name ="Biometric Terminal Capabilities",TagLengthRepresentation = TagLengthType.Fixed},
                  new TLV { Id = "BF4C", Name = "Biometric Try Counters Template",Length=0},//->Edit for VAR
                  new TLV { Id = "81", Name = "Biometric Type",Length=0},//->Edit for VAR
                  new TLV { Id = "9F0B", Name = "Cardholder \r\nName Extended",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL},
                  new TLV { Id = "8E", Name = "Cardholder \r\nVerification \r\nMethod (CVM) \r\nList",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                  new TLV { Id = "9F34", Name ="Cardholder \r\nVerification \r\nMethod (CVM) \r\nResults",TagLengthRepresentation = TagLengthType.Fixed},
                  new TLV { Id = "8F", Name ="Certification \r\nAuthority Public \r\nKey Index",TagLengthRepresentation = TagLengthType.Fixed },
                  new TLV { Id = "9F22", Name ="Certification \r\nAuthority Public \r\nKey Index",TagLengthRepresentation = TagLengthType.Fixed },
                  new TLV { Id = "73", Name = "Directory \r\nDiscretionary \r\nTemplate",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                  new TLV { Id = "9F49", Name = "Dynamic Data \r\nAuthentication \r\nData Object List \r\n(DDOL)",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                  new TLV { Id = "DF51", Name = "Enciphered \r\nBiometric Data",Length=0},//->Edit for VAR
                  new TLV { Id = "DF50", Name = "Enciphered \r\nBiometric Key \r\nSeed",Length=0},//->Edit for NFC or N1C
                  new TLV { Id = "DF50", Name ="Facial Try \r\nCounter",TagLengthRepresentation = TagLengthType.Fixed},
                  new TLV { Id = "BF0C", Name = "File Control \r\nInformation \r\n(FCI) Issuer \r\nDiscretionary \r\nData",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                  new TLV { Id = "DF51", Name ="Finger Try \r\nCounter",TagLengthRepresentation = TagLengthType.Fixed },
                 // new TLV { Id = "9F2E", Name = "Integrated \r\nCircuit Card \r\n(ICC) PIN \r\nEncipherment \r\nPublic Key \r\nExponent",minLen=1,maxLen=3},//->Edit for OR 
                  new TLV { Id = "9F2F", Name ="Integrated \r\nCircuit Card \r\n(ICC) PIN \r\nEncipherment \r\nPublic Key \r\nRemainder",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F46", Name ="Integrated \r\nCircuit Card \r\n(ICC) Public Key \r\nCertificate",TagLengthRepresentation = TagLengthType.Fixed },
                  // new TLV { Id = "9F47", Name = "Integrated \r\nCircuit Card \r\n(ICC) Public Key \r\nExponent",minLen=1,maxLen=3},//->Edit for OR
                   new TLV { Id = "9F48", Name ="Integrated \r\nCircuit Card \r\n(ICC) Public Key \r\nRemainder",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "91", Name = "Issuer \r\nAuthentication \r\nData",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                   new TLV { Id = "9F11", Name ="Issuer Code \r\nTable Index",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "5F28", Name ="Issuer Country \r\nCode",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "5F55", Name ="Issuer Country \r\nCode (alpha2 \r\nformat)",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "5F56", Name ="Issuer Country \r\nCode (alpha3 \r\nformat)",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "42", Name ="Issuer \r\nIdentification \r\nNumber (IIN)",TagLengthRepresentation = TagLengthType.Fixed },
                  // new TLV { Id = "9F0C", Name ="Issuer \r\nIdentification \r\nNumber \r\nExtended (IINE)",minLen=3,maxLen=4 },//->Edit for OR
                   new TLV { Id = "5F2D", Name = "Language \r\nPreference",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                   new TLV { Id = "9F25", Name ="Last 4 Digits of \r\nPAN",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "9F13", Name ="Last Online \r\nApplication \r\nTransaction \r\nCounter (ATC) \r\nRegister",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "9F4D", Name ="Log Entry ",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "9F4F", Name = "Log Format ",Length=0},//->Edit for VAR
                   new TLV { Id = "9F14", Name ="Lower \r\nConsecutive \r\nOffline Limit",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "DF52", Name ="MAC of \r\nEnciphered \r\nBiometric Data",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "BF4B", Name = "Online BIT \r\nGroup Template ",Length=0},//->Edit for VAR
                   new TLV { Id = "DF53", Name ="Palm Try \r\nCounter ",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F24", Name ="Payment \r\nAccount \r\nReference (PAR) ",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F17", Name ="Personal \r\nIdentification \r\nNumber (PIN) \r\nTry Counter ",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F39", Name ="Point-of-Service \r\n(POS) Entry \r\nMode",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F38", Name = "Processing \r\nOptions Data \r\nObject List \r\n(PDOL)",Length=0},//->Edit for VAR
                   new TLV { Id = "70", Name = "READ RECORD \r\nResponse \r\nMessage \r\nTemplate",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                   new TLV { Id = "80", Name = "Response \r\nMessage \r\nTemplate \r\nFormat 1",Length=0},//->Edit for VAR
                   new TLV { Id = "77", Name = "Response \r\nMessage \r\nTemplate \r\nFormat 2",Length=0},//->Edit for VAR
                   new TLV { Id = "5F30", Name ="Service Code ",TagLengthRepresentation=TagLengthType.Fixed },
                   new TLV { Id = "88", Name ="Short File \r\nIdentifier (SFI) ",TagLengthRepresentation = TagLengthType.Fixed },
                   new TLV { Id = "9F33", Name ="Terminal \r\nCapabilities",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F1A", Name ="Terminal \r\nCountry Code",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F1B", Name ="Terminal Floor \r\nLimit",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F1C", Name ="Terminal \r\nIdentification",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9F1D", Name = "Terminal Risk \r\nManagement \r\nData",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                   new TLV { Id = "9F35", Name ="Terminal Type",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "95", Name ="Terminal \r\nVerification \r\nResults",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "97", Name = "Transaction \r\nCertificate Data \r\nObject List \r\n(TDOL)",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                   new TLV { Id = "98", Name ="Transaction \r\nCertificate (TC) \r\nHash Value",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "5F2A", Name ="Transaction \r\nCurrency Code",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "5F36", Name ="Transaction \r\nCurrency \r\nExponent",TagLengthRepresentation = TagLengthType.Fixed},
                   new TLV { Id = "9A", Name ="Transaction \r\nDate",TagLengthRepresentation = TagLengthType.Fixed},
                   //new TLV { Id = "99", Name = "Transaction \r\nPersonal \r\nIdentification \r\nNumber (PIN) \r\nData",Length=0},//->Edit for VAR
                   new TLV { Id = "9F3C", Name ="Transaction \r\nReference \r\nCurrency Code", TagLengthRepresentation=TagLengthType.Fixed},


                //Nan
                 new TLV { Id = "9F04", Name ="Amount,Other(Binary)",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F03", Name = "Amount,Other(Numeric)",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F3A", Name = "Amount,Reference Currency",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F26", Name = "Application Cryptogram",TagLengthRepresentation=TagLengthType.Fixed},
                 new TLV { Id = "9F42", Name = "Application Currency Code",TagLengthRepresentation=TagLengthType.Fixed},
                 new TLV { Id = "9F44", Name = "Application Currency Exponent",TagLengthRepresentation=TagLengthType.Fixed},
                 new TLV { Id = "9F05", Name = "Application Discretionary Data",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "5F25", Name = "Application Effective Date",TagLengthRepresentation=TagLengthType.Fixed},
                 new TLV { Id = "5F24", Name = "Application Expiration Date",TagLengthRepresentation=TagLengthType.Fixed},
                 new TLV { Id = "94", Name = "Application File Locator (AFL)",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "87", Name = "Application Priority Indicator",TagLengthRepresentation=TagLengthType.Fixed},
                 new TLV { Id = "9F3B", Name = "Application Reference Currency",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "9F43", Name = "Application Reference Currency Exponent",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "8A", Name = "Authorisation Response Code",TagLengthRepresentation=TagLengthType.Fixed},
                 //new TLV { Id = "5F54", Name = "Bank Identifier Code (BIC)",minLen=8,maxLen=11},//->Edit for OR 
                 //new TLV { Id = "A1", Name = "Biometric Header Template (BHT)",Length=0},//->Edit for VAR
                 //new TLV { Id = "7F60", Name = "Biometric Information Template (BIT)",Length=0},//->Edit for VAR
                // new TLV { Id = "9F31", Name = "Card BIT Group Template",Length=0},//->Edit for VAR
                // new TLV { Id = "BF4E", Name = "Biometric Verification Data Template",Length=0},//->Edit for VAR
                 new TLV { Id = "8C", Name = "Card Risk Management Data Object List 1 (CDOL1)",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "8D", Name = "Card Risk Management Data Object List 2 (CDOL2)",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                // new TLV { Id = "83", Name = "Command Template",Length=0},//->Edit for VAR
                 new TLV { Id = "9F45", Name = "Data Authentication Code",TagLengthRepresentation=TagLengthType.Fixed},
                 new TLV { Id = "84", Name = "Dedicated File (DF) Name",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "9D", Name = "Directory Definition File (DDF) Name",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "A5", Name = "File Control Information (FCI) Proprietary Template",Length=0},//->Edit for VAR
                 new TLV { Id = "6F", Name = "File Control Information (FCI) Template",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "9F4C", Name = "ICC Dynamic Number",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "9F2D", Name = "Integrated Circuit Card (ICC) PIN Encipherment Public Key Certificate (RSA)",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "5F53", Name = "International Bank Account Number (IBAN)",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "DF52", Name = "Iris Try Counter",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F0D", Name = "Issuer Action Code – Default",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F0E", Name = "Issuer Action Code – Denial",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F0F", Name = "Issuer Action Code – Online",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F10", Name = "Issuer Application Data",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "90", Name = "Issuer Public Key Certificate",TagLengthRepresentation = TagLengthType.Fixed},
                // new TLV { Id = "9F32", Name = "Issuer Public Key Exponent",minLen=1,maxLen=3},//->Edit for OR 
                 new TLV { Id = "92", Name = "Issuer Public Key Remainder",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "86", Name = "Issuer Script Command",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "9F18", Name = "Issuer Script Identifier",TagLengthRepresentation = TagLengthType.Fixed},
                 //new TLV { Id = "71", Name = "Issuer Script Template 1",Length=0},//->Edit for VAR
                // new TLV { Id = "72", Name = "Issuer Script Template 2",Length=0},//->Edit for VAR
                 new TLV { Id = "5F50", Name = "Issuer URL",Length=0},//->Edit for VAR
                 new TLV { Id = "9F15", Name = "Merchant Category Code",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL},
                 new TLV { Id = "9F16", Name = "Merchant Identifier",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F4E", Name = "Merchant Name and Location",Length=0},//->Edit for VAR
                 new TLV { Id = "BF4A", Name = "Offline BIT Group Template",Length=0},//->Edit for VAR
                 new TLV { Id = "BF4D", Name = "Preferred Attempts Template23",Length=0},//->Edit for VAR
                 new TLV { Id = "DF50", Name = "Preferred Facial Attempts",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "DF51", Name = "Preferred Finger Attempts",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "DF52", Name = "Preferred Iris Attempt",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "DF53", Name = "Preferred Palm Attempts",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "DF54", Name = "Preferred Voice Attempts",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F4B", Name = "Signed Dynamic Application Data",Length=0},//->Edit for N1C
                 new TLV { Id = "93", Name = "Signed Static Application Data",Length=0},//->Edit for N1
                 new TLV { Id = "9F4A", Name = "Static Data Authentication Tag List",Length=0},//->Edit for VAR
                 new TLV { Id = "9F19", Name = "Token Requestor ID",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F1F", Name = "Track 1 Discretionary Data",Length=0},//->Edit for VAR
                 new TLV { Id = "9F20", Name = "Track 2 Discretionary Data",Length=0},//->Edit for VAR
                 new TLV { Id = "9F3D", Name = "Transaction Reference Currency Exponent",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F41", Name = "Transaction Sequence Counter",TagLengthRepresentation = TagLengthType.L | TagLengthType.LL | TagLengthType.LLL },
                 new TLV { Id = "9B", Name = "Transaction Status Information",Length=2},
                 new TLV { Id = "9F21", Name = "Transaction Time",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9C", Name = "Transaction Type",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "9F23", Name = "Upper Consecutive Offline Limit",TagLengthRepresentation = TagLengthType.Fixed},
                 new TLV { Id = "DF54", Name = "Voice Try Counter",TagLengthRepresentation = TagLengthType.Fixed},
                               
             
                
            };

            List<TLV> Tags = ParseEMVData(emvData, emvTags);

        
            Console.WriteLine("Tags are:\n");
            foreach (var tag in Tags)
            {
                string tagLengthDisplay = tag.Length.ToString("D2");
                Console.WriteLine($"Tag ID: {tag.Id}");
                Console.WriteLine($"Tag Length: {tagLengthDisplay}");
                Console.WriteLine($"Tag Name: {tag.Name}");
                Console.WriteLine($"Tag Value: {tag.Value}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.ReadLine();
    }
    static List<TLV> ParseEMVData(string emvData, List<TLV> emvTags)
    {
        List<TLV> Tags = new List<TLV>();
        int index = 0;

        while (index < emvData.Length)
        {
            string tagId = emvData.Substring(index, 2);
            index += 2;

            string tagIdSecondHalf = "";

            if (tagId == "9F" || tagId == "5F")
            {
                tagIdSecondHalf = emvData.Substring(index, 2);
                index += 2;
                tagId = tagId + tagIdSecondHalf;
            }
            string tagLengthStr = emvData.Substring(index, 2);
            int tagLengthValue = Convert.ToInt32(tagLengthStr, 16);
            int a = 1;
            foreach (var tlv in emvTags)
            {
                if (tlv.Id == tagId)
                {
                    if (tlv.Length == -1)
                    {
                        a = 0;
                        break;
                    }
                    if (tlv.TagLengthRepresentation == TagLengthType.Fixed)
                    {
                        a = 0;
                        break;
                    }
                    //if (!tlv.orLength)
                    //{
                    //    if (tagLengthValue >= tlv.minLen && tagLengthValue <= tlv.maxLen)
                    //    {
                    //        a = 0;
                    //    }
                    //}
                    if ((tlv.TagLengthRepresentation & (TagLengthType.L | TagLengthType.LL | TagLengthType.LLL)) != 0)
                    {
                        a = 0;
                        break;
                    }


                }
            }
            index += 2;
            string tagValue = emvData.Substring(index, tagLengthValue * 2);

            index += tagLengthValue * 2;
            TLV emvTag = new TLV() { };
            if (a == 1)
            {
                emvTag = new TLV
                {
                    Id = tagId,
                    TagIdSecondHalf = tagIdSecondHalf,
                    Length = tagLengthValue,
                    Value = "Invalid Length given by the user",
                    Name = GetTagName(emvTags, tagId)
                };
            }
            else
            {
                emvTag = new TLV
                {
                    Id = tagId, 
                    TagIdSecondHalf = tagIdSecondHalf,
                    Length = tagLengthValue,
                    Value = tagValue,
                    Name = GetTagName(emvTags, tagId) 
                };
            }
            Tags.Add(emvTag);
        }
        return Tags;
    }
    static string GetTagName(List<TLV> emvTags, string tagId)
    {
       
        var tag = emvTags.Find(t => t.Id == tagId);
        return tag?.Name ?? "";
    }
}
