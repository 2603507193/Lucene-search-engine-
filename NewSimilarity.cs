using Lucene.Net.Search;
using FieldInvertState = Lucene.Net.Index.FieldInvertState;

namespace LuceneAdvancedSearchApplication
{
    public class NewSimilarity : DefaultSimilarity
    {

        /// <summary>Implemented as <c>sqrt(freq)</c>. </summary>
        public override float Tf(float freq)
        {
            
            //return (float)System.Math.Sqrt(freq);
            return (float)(1 + System.Math.Log10(freq)) ;
            
        }

        public override float Idf(int docFreq, int numDocs)
        {
            return (float)(1 + System.Math.Log((numDocs - docFreq) / docFreq));
        }
        //public void BM25()
        //{
        //    IndexWriterConfig config = new IndexWriterConfig(Version.LUCENE_4_9, analyzer);
        //    searcher.setSimilarity(new BM25Similarity(1.2, 0.75));
        //    config.setSimilarity(new BM25Similarity(1.2, 0.75));
        //}

    }

}