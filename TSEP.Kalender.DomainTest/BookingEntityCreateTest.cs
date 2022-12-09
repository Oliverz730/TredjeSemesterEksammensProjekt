using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Domain.Model;
using TSEP.Kalender.Domain.DomainServices;
using Moq;

namespace TSEP.Kalender.DomainTest
{
    public class BookingEntityCreateTest
    {
        [Theory]
        [InlineData(3000000)]
        [InlineData(1)]

        public void Given_StartDate_Is_Before_EndDate_And_No_Overlap_BookingEntity_Is_Created(int offset)
        {
            //Arrange
            DateTime start = DateTime.Now;
            DateTime end = start + TimeSpan.FromSeconds(offset);

            var mock = new Mock<IBookingDomainService>();
            mock.Setup(m => m.BookingExsistsOnDate(It.IsAny<DateTime>(), It.IsAny<DateTime>(), string.Empty)).Returns(false);

            //Act
            var sut = new BookingEntity(mock.Object, start, end, string.Empty);

            //Assert
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3000)]
        public void Given_StartDate_Is_After_EndDate_And_No_Overlap_Then_ArgumentException_Is_Thrown(int offset)
        {

            //Arrange
            DateTime start = DateTime.Now;
            DateTime end = start + TimeSpan.FromSeconds(offset);

            var mock = new Mock<IBookingDomainService>();
            mock.Setup(m => m.BookingExsistsOnDate(It.IsAny<DateTime>(), It.IsAny<DateTime>(), string.Empty)).Returns(false);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new BookingEntity(mock.Object, start, end, string.Empty));
        }

        [Fact]
        public void Given_Date_Has_No_Overlap_Then_BookingEntity_Is_Created()
        {

            //Arrange
            DateTime start = DateTime.Now;
            DateTime end = start + TimeSpan.FromSeconds(1000);

            var mock = new Mock<IBookingDomainService>();
            mock.Setup(m => m.BookingExsistsOnDate(It.IsAny<DateTime>(), It.IsAny<DateTime>(), string.Empty)).Returns(false);

            //Act
            var sut = new BookingEntity(mock.Object, start, end, string.Empty);

            //Assert
        }
        [Fact]
        public void Given_Date_Has_Overlap_Then_ArgumentException_Is_Thrown()
        {

            //Arrange
            DateTime start = DateTime.Now;
            DateTime end = start + TimeSpan.FromSeconds(1000);

            var mock = new Mock<IBookingDomainService>();
            mock.Setup(m => m.BookingExsistsOnDate(It.IsAny<DateTime>(), It.IsAny<DateTime>(), string.Empty)).Returns(true);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new BookingEntity(mock.Object, start, end, string.Empty));
        }
    }
}
