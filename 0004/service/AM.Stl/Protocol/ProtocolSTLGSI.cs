using Core.Logs;

namespace AM.Stl.Protocol
{
    public class ProtocolSTLGSI
    {
        private byte[] header;
        public byte[] Header { get => header; private set => header = value; }

        public ProtocolStl Helper = new ProtocolStl();

        public ProtocolSTLGSI()
        {
            Header = new byte[1024];
        }

        public byte[] Build(string title, int totalNumberOfTtiBlocks, int totalNumberOfSubtitles,
            int TotalNumberOfSubtitleGroups,
            int maximumNumberOfDisplayCharactesr,
            int maximumNumberOfDisplayRows,
            TimeSpan startOfProgramme,
            TimeSpan firstInCue,
            int totalNumberOfDisk = 1,
            int distSequenceNumber = 1,
            string countryOfOrigin = "FRA",
            string languageCode = "0F")
        {
            byte[] temp;


            Log.UI.Message($"Start building the STL file...");
            Log.UI.Message($"- Title: {title}");
            Log.UI.Message($"- Subtitles count: {totalNumberOfTtiBlocks}");
            Log.UI.Message($"- Total rows count: {totalNumberOfSubtitles}");
            Log.UI.Message($"- Maximum number of display characters: {maximumNumberOfDisplayCharactesr}");
            Log.UI.Message($"- Maximum number of display rows: {maximumNumberOfDisplayRows}");
            Log.UI.Message($"- TotalNumber of disk: {totalNumberOfDisk}");
            Log.UI.Message($"- Dist sequence number: {distSequenceNumber}");
            Log.UI.Message($"- Country of origin: {countryOfOrigin}");
            Log.UI.Message($"- Language code: {languageCode}");
            Log.UI.Message($"------------------------------------------------------");

            temp = Helper.GetCodePageNumber(CodePage.Multilingual);
            Array.Copy(temp, 0, header, 0, temp.Length);


            temp = Helper.GetDiskFormatCode();
            Array.Copy(temp, 0, header, 3, temp.Length);

            header[11] = Helper.GetDisplayStandartCode(1);

            temp = Helper.GetCharacterCodeTable(CharacterCodeTable.Latin);
            Array.Copy(temp, 0, header, 12, temp.Length);

            temp = Helper.GetLanguageCode(languageCode);
            Array.Copy(temp, 0, header, 14, temp.Length);

            temp = Helper.GetTranslated(title, 32);
            Array.Copy(temp, 0, header, 16, temp.Length);

            temp = Helper.GetTranslated(""); //episode
            Array.Copy(temp, 0, header, 48, temp.Length);

            temp = Helper.GetTranslated(""); //programme title
            Array.Copy(temp, 0, header, 80, temp.Length);

            temp = Helper.GetTranslated(""); //episode title
            Array.Copy(temp, 0, header, 112, temp.Length);

            temp = Helper.GetTranslated(""); //translator's name
            Array.Copy(temp, 0, header, 144, temp.Length);

            temp = Helper.GetTranslated(""); //translator's contact details
            Array.Copy(temp, 0, header, 176, temp.Length);

            temp = Helper.GetTranslated("", 16); //Subtitle list reference code
            Array.Copy(temp, 0, header, 208, temp.Length);



            temp = Helper.GetDate();//Creation date
            Array.Copy(temp, 0, header, 224, temp.Length);

            temp = Helper.GetDate();//Revision date 6
            Array.Copy(temp, 0, header, 230, temp.Length);

            temp = Helper.GetRevisionNumber(1);
            Array.Copy(temp, 0, header, 236, temp.Length);



            temp = Helper.GetTotalNumber(totalNumberOfTtiBlocks);
            Array.Copy(temp, 0, header, 238, temp.Length);

            temp = Helper.GetTotalNumber(totalNumberOfSubtitles);
            Array.Copy(temp, 0, header, 243, temp.Length);

            temp = Helper.GetTotalNumberOfGroups(TotalNumberOfSubtitleGroups);
            Array.Copy(temp, 0, header, 248, temp.Length);



            temp = Helper.GetMaximumNumberOfDisplay(maximumNumberOfDisplayCharactesr);
            Array.Copy(temp, 0, header, 251, temp.Length);

            temp = Helper.GetMaximumNumberOfDisplay(maximumNumberOfDisplayRows);
            Array.Copy(temp, 0, header, 253, temp.Length);

            header[255] = Helper.GetTimeCodeStatus(1);

            temp = Helper.GetStartTime(startOfProgramme);
            Array.Copy(temp, 0, header, 256, temp.Length);

            temp = Helper.GetStartTime(firstInCue);
            Array.Copy(temp, 0, header, 264, temp.Length);

            header[272] = Helper.GetTimeCodeStatus(totalNumberOfDisk);
            header[273] = Helper.GetTimeCodeStatus(distSequenceNumber);

            temp = Helper.GetTranslated(countryOfOrigin, 3);// country of origin
            Array.Copy(temp, 0, header, 274, temp.Length);


            temp = Helper.GetTranslated("", 32); // publisher
            Array.Copy(temp, 0, header, 277, temp.Length);

            temp = Helper.GetTranslated(""); // editor's name
            Array.Copy(temp, 0, header, 309, temp.Length);

            temp = Helper.GetTranslated(""); // editor's contact details
            Array.Copy(temp, 0, header, 341, temp.Length);

            temp = Helper.GetTranslated("", 75); // spare bytes
            Array.Copy(temp, 0, header, 373, temp.Length);

            temp = Helper.GetTranslated("", 576); // User-defined area
            Array.Copy(temp, 0, header, 448, temp.Length);


            return Header;
        }
    }
}
