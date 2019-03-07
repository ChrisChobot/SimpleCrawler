using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCrawler;

namespace SimpleCrawlerTests
{
    [TestClass]
    public class TestWebsite
    {
        const string NonExistingSite = @"https://krzysztofchbt.github.io/HopefullyItWontEverExist.html";
        const string NoKeywordTag = @"https://krzysztofchbt.github.io/NoKeywordTagSite.html";
        const string EmptyKeywordContent = @"https://krzysztofchbt.github.io/EmptyKeywordContentSite.html";
        const string SingleKeywordTag = @"https://krzysztofchbt.github.io/SingleKeywordSite.html";
        const string ManyKeywordTags = @"https://krzysztofchbt.github.io/ManyKeywordSite.html";
        
        [TestMethod]
        public void TestNonExistingSite()
        {
           new App();

            List<KeywordGridRow> gridRows = Website.AnalyseUrl(NonExistingSite);
            Debug.Assert(gridRows == null);
        }

        [TestMethod]
        public void TestEmptyKeywordAnalysys()
        {
            List<KeywordGridRow> gridRows = Website.AnalyseUrl(NoKeywordTag);
            Debug.Assert(gridRows == null);

            gridRows = Website.AnalyseUrl(EmptyKeywordContent);
            Debug.Assert(gridRows == null);
        }

        [TestMethod]
        public void TestSingleKeyword()
        {
            List<KeywordResult> KeywordResults = new List<KeywordResult>();
            KeywordResults.Add(new KeywordResult("This is", 3));

            List<KeywordGridRow> gridRows = Website.AnalyseUrl(SingleKeywordTag);

            Debug.Assert(gridRows != null);
            CompareGridRow(gridRows, KeywordResults);
        }

        [TestMethod]
        public void TestManyKeywords()
        {
            List<KeywordResult> KeywordResults = new List<KeywordResult>();
            KeywordResults.Add(new KeywordResult("This is", 3));
            KeywordResults.Add(new KeywordResult("boom", 2));

            List<KeywordGridRow> gridRows = Website.AnalyseUrl(ManyKeywordTags);
            Debug.Assert(gridRows != null);
            CompareGridRow(gridRows, KeywordResults);
        }

        private void CompareGridRow(List<KeywordGridRow> gridRows, List<KeywordResult> KeywordResults)
        {
            Debug.Assert(gridRows.Count == KeywordResults.Count);

            for (int i = 0; i < gridRows.Count; i++)
            {
                KeywordResult keywordResult = KeywordResults[i];
                int gridRowIndex = gridRows.FindIndex((x) => x.Keyword == keywordResult.Keyword);
                Debug.Assert(gridRowIndex != -1);
                KeywordGridRow gridRow = gridRows[gridRowIndex];

                Debug.Assert(int.Parse(gridRow.Count) == keywordResult.Occurences);
                Debug.Assert(gridRow.Keyword == keywordResult.Keyword);
            }
        }
        
        private struct KeywordResult
        {
            public string Keyword;
            public int Occurences;

            public KeywordResult(string keyword, int occurences)
            {
                Keyword = keyword;
                Occurences = occurences;
            }
        }
    }
}
