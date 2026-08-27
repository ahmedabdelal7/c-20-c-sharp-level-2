using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class NewsArticle
{
    public string Title { get; }
    public string Content { get; }

    public NewsArticle(string title, string content)
    {
        this.Title = title;
        this.Content = content;
    }
}

public class NewsPublisher
{
    public event EventHandler<NewsArticle> NewNewsPublished;

    public void PublishNews(string title, string content)
    {
        PublishNews(new NewsArticle(title, content));
    }
    protected virtual void PublishNews(NewsArticle article)
    {
        NewNewsPublished?.Invoke(this, article);
    }

}

public class NewsSubscriber
{

    public string Name { get; }

    public NewsSubscriber(string name)
    {
        this.Name = name;
    }


    public void Subscribe(NewsPublisher publisher) {
        publisher.NewNewsPublished += HandelOnNewNewsPublished;
    }

    public void UnSubscribe(NewsPublisher publisher)
    {
        publisher.NewNewsPublished -= HandelOnNewNewsPublished;
    }
    public void HandelOnNewNewsPublished(object sender, NewsArticle article)
    {
        Console.WriteLine($"{Name} Received a new news article.");
        Console.WriteLine($"Title   : {article.Title}.");
        Console.WriteLine($"Content : {article.Content}.");
        Console.WriteLine();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        NewsPublisher publisher = new NewsPublisher();

        NewsSubscriber sub1 = new NewsSubscriber("Subscriber 1");
        sub1.Subscribe( publisher );

        NewsSubscriber sub2 = new NewsSubscriber("Subscriber 2");
        sub2.Subscribe( publisher );


        publisher.PublishNews("First News", "This is first news.");

        sub1.UnSubscribe( publisher );

        publisher.PublishNews("Second News", "This is second news.");

        sub2.UnSubscribe( publisher ); 

        publisher.PublishNews("Third News", "This is third news.");


        Console.ReadKey();

    }
}
