using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Document and Field
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory
using Lucene.Net.Search; // for IndexSearcher
using Lucene.Net.QueryParsers;  // for QueryParser
using Lucene.Net.Analysis.Snowball; // for snowball analyser 
using System.Windows.Forms;
using Syn.WordNet;


namespace LuceneAdvancedSearchApplication
{
    class LuceneAdvancedSearchApplication
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzer;
        Lucene.Net.Index.IndexWriter writer;
        IndexSearcher searcher;
        QueryParser parser;        
        Similarity newSimilarity;// Activity 9
        //PorterStemmerAlgorithm.PorterStemmer myStemmer;
        public string[] stopWords = { "a", "an", "and", "are", "as", "at", "be", "but", "by", "for", "if", "in", "into", "is", "it", "no", "not", "of", "on", "or", "such", "that", "the", "their", "then", "there", "these", "they", "this", "to", "was", "will", "with" };
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        const string TEXT_FN = "Text";
        bool firtTime = true;
        bool fTime = true;
      
        public LuceneAdvancedSearchApplication()
        {

        }
        public LuceneAdvancedSearchApplication(int button)
        {
            luceneIndexDirectory = null;
            writer = null;
            firtTime = true;
            fTime = true;
            switch (button)
            {
                case 1:
                    analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                    break;
                case 2:
                    analyzer = new SnowballAnalyzer(Lucene.Net.Util.Version.LUCENE_30, "English");
                    break;
                case 3:
                    analyzer = new SnowballAnalyzer(Lucene.Net.Util.Version.LUCENE_30, "English", stopWords);
                    break;
                case 4:
                    analyzer = new KeywordAnalyzer();
                    break;
                default:
                    break;
            }
            //analyzer = new Lucene.Net.Analysis.WhitespaceAnalyzer();
            //analyzer = new Lucene.Net.Analysis.SimpleAnalyzer(); // Activity 5
            //analyzer = new Lucene.Net.Analysis.StopAnalyzer(); // Activity 5
            //analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30); // Activity 5
            //analyzer = new SnowballAnalyzer(Lucene.Net.Util.Version.LUCENE_30, "English", stopWords); // Activity 7
            // myStemmer = new PorterStemmerAlgorithm.PorterStemmer();
            parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, TEXT_FN, analyzer);
            newSimilarity = new NewSimilarity(); // Activity 9

        }

        static string OutputFileDetails(string name)
        {
            
            System.IO.TextReader reader = new System.IO.StreamReader(name);
            String fileContent = reader.ReadToEnd();
            //Console.Write(fileContent);
            reader.Close();
            //Console.WriteLine("Filename " + name);
            return fileContent;
            //Console.WriteLine("Filename " + name + " Word Count " + numWords);

        }
        static List<string> WalkDirectoryTree(String path)
        {
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(path);
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;
            List<string> fileContents = new List<string>();

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.*");
            }

            catch (UnauthorizedAccessException e)
            {
                System.Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    string name = fi.FullName;
                    fileContents.Add(OutputFileDetails(name));
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    string name = dirInfo.FullName;
                    WalkDirectoryTree(name);
                }
            }
            return fileContents;
        }
        /// <summary>
        /// Creates the index at a given path
        /// </summary>
        /// <param name="indexPath">The pathname to create the index</param>
        public void CreateIndex(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
            writer.SetSimilarity(newSimilarity); 
        }

        /// <summary>
        /// Indexes a given string into the index
        /// </summary>
        /// <param name="text">The text to index</param>
        public void IndexText(string text)
        {

            Lucene.Net.Documents.Field field = new Field(TEXT_FN, text, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
            Lucene.Net.Documents.Document doc = new Document();
            field.Boost = 5;
            doc.Add(field);
            writer.AddDocument(doc);
        }


        /// <summary>
        /// Flushes the buffer and closes the index
        /// </summary>
        public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }


        /// <summary>
        /// Creates the searcher object
        /// </summary>
        public void CreateSearcher()
        {
            searcher = new IndexSearcher(luceneIndexDirectory);
            searcher.Similarity = newSimilarity; 
        }

        public string GetAbstract(string text)
        {

            string textAbstract = "";
            //separate by .W
            string[] removeToken1 = new string[] { ".W" };
            //separate by ...
            string[] removeToken2 = new string[] { ".I", ".T", ".A", ".B", "." };
            //separete by . and \n
            char[] removeToken3 = new char[] { '.' };
            //separete txt by .W
            string[] tokens = text.Split(removeToken1, StringSplitOptions.RemoveEmptyEntries);
            //separate first part by removeToken2
            string[] tokens1 = tokens[0].Split(removeToken2, StringSplitOptions.RemoveEmptyEntries);
            //separate second part by removeToken3
            string[] tokens2 = tokens[1].Split(removeToken3, StringSplitOptions.RemoveEmptyEntries);
            //check title and first sentence of abstract
            if (tokens1[1] == tokens2[0])
            {
                //textAbstract = tokens2[1];
                for (int i = 1; i < tokens2.Length; i++)
                {
                    textAbstract += tokens2[i] +".";
                }
            }
            else
            {
                for (int i = 0; i < tokens2.Length; i++)
                {
                    textAbstract += tokens2[i] +".";
                }
            }
            return textAbstract;
        }

        public string GetID(string text)
        {
           string[] removeToken = new string[] { ".I", ".T", ".A", ".B", ".W" };
            string[] ID = text.Split(removeToken, StringSplitOptions.RemoveEmptyEntries);
            return ID[0];
        }
        public string GetTitle(string text)
        {
          
            string[] removeToken = new string[] { ".I", ".T", ".A", ".B", ".W"};
            string[] title = text.Split(removeToken, StringSplitOptions.RemoveEmptyEntries);
            return title[1];  
            
        }
        public string GetAuthors(string text)
        {

            string[] removeToken = new string[] { ".I", ".T", ".A", ".B", ".W" };
            string[] title = text.Split(removeToken, StringSplitOptions.RemoveEmptyEntries);
            return title[2];

        }
        public string Get_b(string text)
        {

            string[] removeToken = new string[] { ".I", ".T", ".A", ".B", ".W" };
            string[] title = text.Split(removeToken, StringSplitOptions.RemoveEmptyEntries);
            return title[3];

        }
        public string GetFirstSentence(string text)
        {
            string firstSentence = "";
            //separate by .W
            string[] removeToken1 = new string[] { ".W" };
            //separate by ...
            string[] removeToken2 = new string[] { ".I", ".T", ".A", ".B", "." };
            //separete by . and \n
            char[] removeToken3 = new char[] { '.' };
            //separete txt by .W
            string[] tokens = text.Split(removeToken1, StringSplitOptions.RemoveEmptyEntries);
            //separate first part by removeToken2
            string[] tokens1 = tokens[0].Split(removeToken2, StringSplitOptions.RemoveEmptyEntries);
            //separate second part by removeToken3
            string[] tokens2 = tokens[1].Split(removeToken3, StringSplitOptions.RemoveEmptyEntries);
            //check title and first sentence of abstract
            if (tokens1[1] == tokens2[0])
            {
                firstSentence = tokens2[1];
            }
            else {
                firstSentence = tokens2[0];
            }
            return firstSentence;
        }
    
        public List<List<string>> MySearchText(string rawQuery, int page, bool first)
        {
            List<string> result = new List<string>();
            List<string> textAbstract = new List<string>();
            List<string> numberofresults = new List<string>();
            List<string> maximunPage = new List<string>();
            List<string> finalquery = new List<string>();
            List<List<string>> myResult = new List<List<string>>();
            List<string> Store_information = new List<string>();
            string finalQuery;  //querytext = querytext.ToLower();  
            //LuceneAdvancedSearchApplication myLucene = new LuceneAdvancedSearchApplication();
            Query query = parser.Parse(rawQuery);
            string querytext = query.ToString();



            List<string> synonym = new List<string>();
            TopDocs results;
            if (GUIForm.expandState)
            {
                var synSetList = GUIForm.wordNet.GetSynSets(rawQuery);
                foreach (var synSet in synSetList)
                {
                    foreach (var word in synSet.Words)
                    {
                        if(!synonym.Contains(word))
                        {

                            synonym.Add(word);
                        }                       
                    }
                }
                if (GUIForm.Weight)
                {
                    synonym[0] += "^5";
                    first = false;
                }
                string expandQuery = string.Join(" ", synonym);
                Query expandedquery = parser.Parse(expandQuery);
                finalQuery = expandQuery.ToString();
                finalquery.Add("Final Query: " + finalQuery);
                results = searcher.Search(expandedquery, 100);
            }
            else
            {
                string[] queryArray = querytext.Split(new[] { "Text:" }, StringSplitOptions.RemoveEmptyEntries);
                results = searcher.Search(query, 100);
                finalQuery = queryArray[0];
                finalquery.Add("Final Query: " + finalQuery);
            }
        

            
            //System.Console.WriteLine("Number of results is " + results.TotalHits);
            if (results.ScoreDocs.Length == 0)
            {
                MessageBox.Show("There is no such information");        
            }

            //int maxPage = results.ScoreDocs.Length/10 + 1 ;
            
            int modul = results.ScoreDocs.Length % 10;
            int maxPage = 0;
            if (results.ScoreDocs.Length % 10 != 0)
            {
                maxPage = results.ScoreDocs.Length / 10 + 1;
            }
            else
            {
                maxPage = results.ScoreDocs.Length / 10;
            }
            maximunPage.Add(maxPage.ToString());
            numberofresults.Add("Number of results is: " + results.TotalHits.ToString());
            // MessageBox.Show(results.TotalHits.ToString(), "Number of results is ");
      
            if (page < maxPage)
            {
                for (int rank = (page-1) * 10; rank < page * 10; rank++)
                {
                    Lucene.Net.Documents.Document doc = searcher.Doc(results.ScoreDocs[rank].Doc);
                    string myFieldValue = doc.Get(TEXT_FN).ToString();
                    string title = GetTitle(myFieldValue);
                    string Author = GetAuthors(myFieldValue);
                    string b = Get_b(myFieldValue);
                    string firstSentence = GetFirstSentence(myFieldValue);
                    string text_abstract = GetAbstract(myFieldValue);
                    string ID = GetID(myFieldValue);
                    Store_information.Add(finalQuery + "\t\t" + "Q0" + "\t\t" + ID + "\t\t" + rank + "\t\t" + results.ScoreDocs[rank].Score + "\t\t" + "n9599291_n9814434_n9754911" + "\n");

                    result.Add("Rank:" + (rank + 1) + "\nTitle: " + title + "\nAuthor: " + Author + "\nBibliographic information: "+ b + "\nfrist Sentence:  " + firstSentence + "\n" +"\n-------------------");
                    textAbstract.Add("Abstract:"+ text_abstract);        
                }
           
            }
            else {
                for (int rank = (maxPage-1) * 10; rank < (maxPage-1) * 10 + modul; rank++)
                {
                    Lucene.Net.Documents.Document doc = searcher.Doc(results.ScoreDocs[rank].Doc);
                    string myFieldValue = doc.Get(TEXT_FN).ToString();
                    string ID = GetID(myFieldValue);
                    string title = GetTitle(myFieldValue);
                    string Author = GetAuthors(myFieldValue);
                    string b = Get_b(myFieldValue);
                    string firstSentence = GetFirstSentence(myFieldValue);
                    string text_abstract = GetAbstract(myFieldValue);
                    Store_information.Add(finalQuery + "\t\t" + "Q0" + "\t\t" + ID + "\t\t" + rank + "\t\t" + results.ScoreDocs[rank].Score + "\t\t" + "n9599291_n9814434_n9754911" + "\n");
                    textAbstract.Add("Abstract:" + text_abstract);
                    result.Add("Rank :" + (rank + 1) + "\nTitle: " + title + "\nAuthor: " + Author + "\nBibliographic	information: " + b + "\nfrist Sentence:  " + firstSentence + "\n"+ "\n-------------------");
                   
                }
                //myResult.Add(result);
                //myResult.Add(textAbstract);
                //myResult.Add(maximunPage);
            }
            myResult.Add(result);
            myResult.Add(textAbstract);
            myResult.Add(maximunPage);
            myResult.Add(numberofresults);
            myResult.Add(finalquery);
            myResult.Add(Store_information);
        
            return myResult;
        }
        
        public void CleanUpSearcher()
        {
            searcher.Dispose();
        }


       

        public List<List<string>> OutPut(string userInput, int page, string sourceCollection, string indexPath)
        {
          
            List<string> l = new List<string>();
            l = WalkDirectoryTree(sourceCollection);
            string query = userInput;
            //if (true)
            //{
            //    query = ProcessTokens(userInput);
            //}

            DateTime start = System.DateTime.Now;
            CreateIndex(indexPath);
            //System.Console.WriteLine("Adding Documents to Index");
            int docID = 0;
            foreach (string s in l)
            {
                IndexText(s);
                docID++;
            }
            //System.Console.WriteLine("All documents added.");
            DateTime indexEnd = System.DateTime.Now;
            if (firtTime)
            {
                MessageBox.Show((indexEnd - start).ToString(), "Index Time");
                firtTime = false;
            }

            CleanUpIndexer();
            // Searching Code
            CreateSearcher();
            //SearchText(query, 1);
            List<List<string>> myResult = MySearchText(query, page,true);
            DateTime searchEnd = System.DateTime.Now;
            if (fTime)
            {
                MessageBox.Show((searchEnd - indexEnd).ToString(), "Search Time");
                fTime = false;
            }
       
            CleanUpSearcher();
            return myResult;
        }
        public List<List<string>> OutPut2(string userInput, int page, string sourceCollection, string indexPath)
        {

            List<string> l = new List<string>();
            l = WalkDirectoryTree(sourceCollection);
            string query = userInput;    
            CreateIndex(indexPath);       
            int docID = 0;
            foreach (string s in l)
            {
                IndexText(s);
                docID++;
            }
            CleanUpIndexer();
            CreateSearcher();         
            List<List<string>> myResult = MySearchText2(query, page);     
            CleanUpSearcher();
            return myResult;
        }


        public List<List<string>> MySearchText2(string querytext, int page)
        {
            List<string> result = new List<string>();
            List<string> textAbstract = new List<string>();
            List<string> numberofresults = new List<string>();
            List<string> maximunPage = new List<string>();
            List<List<string>> myResult = new List<List<string>>();
        
        
            Query query = parser.Parse(querytext);

            querytext = query.ToString();
            //string[] queryArray = querytext.Split(new[] { "Text:" }, StringSplitOptions.RemoveEmptyEntries);
            //string finalQuery = string.Join(",", queryArray);

            TopDocs results = searcher.Search(query, 100);
            int maxPage = 0;
            if (results.ScoreDocs.Length % 10 != 0)
            {
                maxPage = results.ScoreDocs.Length / 10 + 1;
            }
            else
            {
                maxPage = results.ScoreDocs.Length / 10;
            }
            //System.Console.WriteLine("Number of results is " + results.TotalHits);
            if (results.ScoreDocs.Length == 0)
            {
                MessageBox.Show("There is no such information");
            }

            maximunPage.Add(maxPage.ToString());
            int modul = results.ScoreDocs.Length % 10;
            numberofresults.Add("Number of results is: " + results.TotalHits.ToString());

            if (page < maxPage)
            {
                for (int rank = (page-1) * 10; rank < page * 10; rank++)
                {
                    Lucene.Net.Documents.Document doc = searcher.Doc(results.ScoreDocs[rank].Doc);
                    string myFieldValue = doc.Get(TEXT_FN).ToString();
                    string title = GetTitle(myFieldValue);
                    string Author = GetAuthors(myFieldValue);
                    string b = Get_b(myFieldValue);
                    string firstSentence = GetFirstSentence(myFieldValue);
                    string text_abstract = GetAbstract(myFieldValue);
                    //result.Add("abstract+"+ text_abstract);
                 
                    result.Add("Rank:" + (rank+1) + "\nTitle: " + title + "\nAuthor: " + Author + "\nBibliographic information: " + b + "\nfrist Sentence:  " + firstSentence + "\n" + "\n-------------------");
                    textAbstract.Add("Abstract:" + text_abstract);
                  
                }
                
            }
            else
            {
                for (int rank = (maxPage - 1) * 10; rank < (maxPage - 1) * 10 + modul; rank++)
                {
                    Lucene.Net.Documents.Document doc = searcher.Doc(results.ScoreDocs[rank].Doc);
                    string myFieldValue = doc.Get(TEXT_FN).ToString();
                    string title = GetTitle(myFieldValue);
                    string Author = GetAuthors(myFieldValue);
                    string b = Get_b(myFieldValue);
                    string firstSentence = GetFirstSentence(myFieldValue);
                    string text_abstract = GetAbstract(myFieldValue);
                    textAbstract.Add("Abstract:" + text_abstract);
                    result.Add("Rank :" + (rank + 1) + "\nTitle: " + title + "\nAuthor: " + Author + "\nBibliographic	information: " + b + "\nfrist Sentence:  " + firstSentence + "\n" + "\n-------------------");
                
                }
            
            }
            myResult.Add(result);
            myResult.Add(textAbstract);
            myResult.Add(maximunPage);
            myResult.Add(numberofresults);
         
            return myResult;
        }

        [STAThread]
        static void Main(string[] args)
        {

            
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUIForm());
        }
       
    }
}
