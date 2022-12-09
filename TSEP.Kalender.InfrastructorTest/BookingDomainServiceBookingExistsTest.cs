using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using TSEP.SqlDbContext;
using TSEP.Kalender.Domain.Model;
using TSEP.Kalender.Domain.DomainServices;
using TSEP.Kalender.Infrastructor.DomainServices;



namespace TSEP.Kalender.InfrastructorTest
{
    public class BookingDomainServiceBookingExistsTest
    {
        [Theory]
        [InlineData(25)]    //Timer
        void Given_Data_Has_No_Overlap_Return_False(int offset)
        {
            //Arrange

            //Input Data
            DateTime start1 = DateTime.Now + TimeSpan.FromHours(offset);
            DateTime end1 = DateTime.Now + TimeSpan.FromDays(1) + TimeSpan.FromHours(offset);

            //Fake Db Data
            DateTime start2 = DateTime.Now;
            DateTime end2 = DateTime.Now + TimeSpan.FromDays(1);

            var serviceMoq = new Mock<IBookingDomainService>();
            serviceMoq.Setup(s => s.BookingExsistsOnDate(It.IsAny<DateTime>(), It.IsAny<DateTime>(), string.Empty)).Returns(false);

            IList<BookingEntity> data = new List<BookingEntity>()
            {
                new BookingEntity(serviceMoq.Object, start2, end2, string.Empty)
            };

            var moq = new Mock<TredjeSemesterEksamensProjektContext>();
            moq.Setup(c => c.BookingEntities).ReturnsDbSet(data);

            IBookingDomainService sut = new BookingDomainService(moq.Object);

            //Act
            bool expectFalse = sut.BookingExsistsOnDate(start1, end1, string.Empty);

            //Assert
            Assert.False(expectFalse);
        }

        [Theory]
        [InlineData(20)]    //Timer
        void Given_Data_Has_Overlap_Return_True(int offset)
        {
            //Arrange

            //Input Data
            DateTime start1 = DateTime.Now + TimeSpan.FromHours(offset);
            DateTime end1 = DateTime.Now + TimeSpan.FromDays(1) + TimeSpan.FromHours(offset);

            //Fake Db Data
            DateTime start2 = DateTime.Now;
            DateTime end2 = DateTime.Now + TimeSpan.FromDays(1);

            var serviceMoq = new Mock<IBookingDomainService>();
            serviceMoq.Setup(s => s.BookingExsistsOnDate(It.IsAny<DateTime>(), It.IsAny<DateTime>(), string.Empty)).Returns(false);

            IList<BookingEntity> data = new List<BookingEntity>()
            {
                new BookingEntity(serviceMoq.Object, start2, end2, string.Empty)
            };

            var moq = new Mock<TredjeSemesterEksamensProjektContext>();
            moq.Setup(c => c.BookingEntities).ReturnsDbSet(data);

            IBookingDomainService sut = new BookingDomainService(moq.Object);

            //Act
            bool expectTrue = sut.BookingExsistsOnDate(start1, end1, string.Empty);

            //Assert
            Assert.True(expectTrue);
        }

    }
}
