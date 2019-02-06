using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ubtnews.Data.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                 table: "Categories",
                 columns: new[] { "Id", "Name" },
                 values: new object[,]
                 {
                     {1, "Economy" },
                     {2, "Sports" },
                     {3, "Lifestyle" },
                     {4, "Feminism" },
                     {5, "Fashion" },
                     {6, "Health" },
                     {7, "Cuisine" },
                     {8, "Cars" },
                     {9, "Tech" },
                     {10, "Fun" },
                     {11, "National" },
                     {12, "Art" }
                 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Body", "Img", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, "Far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.", "img1.jpg", new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Even the all-powerful Pointing" },
                    { 2, "She packed her seven versalia, put her initial into the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road, the Line Lane. Pityful a rethoric question ran over her cheek, then she continued her way.", "img2.jpg", new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Made drunk with Longe" },
                    { 3, "A number of such two-sided contests may be arranged in a tournament producing a champion. Many sports leagues make an annual champion by arranging games in a regular sports season, followed in some cases by playoffs. Hundreds of sports exist, from those between single contestants, through to those with hundreds of simultaneous participants, either in teams or competing as individuals. In certain sports such as racing, many contestants may compete, each against all with one winner.", "img3.jpg", new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Measures such as technical performance" },
                    { 4, "On her way she met a copy. The copy warned the Little Blind Text, that where it came from it would have been rewritten a thousand times and everything that was left from its origin would be the word “and” and the Little Blind Text should turn around and return to its own, safe country. But nothing the copy said could convince her and so it didn’t take long until a few insidious Copy Writers ambushed her, made her drunk with Longe and Parole and dragged her into their agency, where they abused her for their projects again and again.", "img4.jpg", new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "On her way she met a copy" },
                    { 5, "She packed her seven versalia, put her initial into the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road, the Line Lane. Pityful a rethoric question ran over her cheek, then she continued her way.", "img5.jpg", new DateTime(2019, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "A small river named Duden" },
                    { 6, "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar. The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen.", "img6.jpg", new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leave for the far world of grammar" }
                });

            migrationBuilder.InsertData(
               table: "ArticleCategories",
               columns: new[] {"Id", "ArticleId", "CategoryId" },
               values: new object[,]
               {
                   {1, 1, 3 },
                   {2, 1, 6 },
                   {3, 1, 11 },

                   {4, 2, 1 },
                   {5, 2, 3 },
                   {6, 2, 4 },
                   {7, 2, 11 },

                   {8, 3, 3 },
                   {9, 3, 9 },

                   {10, 4, 1 },
                   {11, 4, 3 },
                   {12, 4, 11 },

                   {13, 5, 4 },
                   {14, 5, 10 },
                   {15, 5, 12 },

                   {16, 6, 2 },
                   {17, 6, 11 },
               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArticleCategories",
                keyColumn: "Id",
                keyValue: 6);



        }
    }
}
