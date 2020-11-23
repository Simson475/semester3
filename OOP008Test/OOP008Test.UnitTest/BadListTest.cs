using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace OOP008Test.UnitTest
{
    public class BadListTest
    {
        [Test]
        [TestCase(5, 4, 5, 5, 5, 5)]
        [TestCase(15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void CountNumbers_CountNumberOf5sInList_Returns4(int number, int expected, params int[] array)
        {
            //Arrange
            BadList badList = new BadList();
            foreach (int item in array)
            {
                badList.Add(item);

            }
            //Act
            int actual = badList.CountNumbers(number);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountNumbers_EmptyList_Returns0_()
        {
            //Arrange
            int expected = 0;
            BadList badList = new BadList();
            //Act
            int actual = badList.CountNumbers(5);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_AddNodeToList_LengthIsIncreasedBy1()
        {
            //Arrange
            BadList badList = new BadList();
            int previousLength = badList.Length;

            //Act
            badList.Add(5);
            int currentLength = badList.Length;
            //Assert
            Assert.IsTrue(previousLength + 1 == currentLength);
        }

        [Test]
        public void IsEmpty_CheckifListIsEmptyAtStart_returntrue()
        {
            //Arrange
            BadList badList = new BadList();
            //Act
            bool actual = badList.IsEmpty;
            //Assert
            Assert.IsTrue(actual);
        }

        [Test]
        [TestCase(0, 5, 5, 4, 3, 2, 1, 6, 7)]
        [TestCase(6, 7, 5, 4, 3, 2, 1, 6, 7)]

        public void Get_UseGetOnExistingIndex_GetsTheDataAtIndex(int index, int expected, params int[] numbers)
        {
            //Arrange
            BadList badList = new BadList();
            foreach (var item in numbers)
            {
                badList.Add(item);
            }
            //Act
            int actual = badList.Get(index);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(70, 7, 5, 4, 3, 2, 1, 6, 7)]
        [TestCase(6, 0, 2, 4)]
        public void Get_UseGetOnNonExistingIndex_Error(int index, params int[] numbers)
        {
            //Arrange
            BadList badList = new BadList();
            foreach (var item in numbers)
            {
                badList.Add(item);
            }
            //Act/Assert
            Assert.Throws<IndexOutOfRangeException>(() => badList.Get(index));
        }

        [Test]
        [TestCase(2, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(5, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(8, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void Remove_RemoveExistingElement_ElementIsRemoved(int index, params int[] numbers)
        {
            //Arrange
            BadList badList = new BadList();
            foreach (var item in numbers)
            {
                badList.Add(item);
            }
            //Act
            int nextElement = badList.Get(index + 1);
            badList.Remove(index);
            int newElement = badList.Get(index);
            //Assert
            Assert.AreEqual(nextElement, newElement);
        }

        [Test]
        [TestCase(0, 2, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(1, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(2, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(3, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(4, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(1, 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(1, 2, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        [TestCase(1, 3, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void InsertAt_getIndexInBound_ReturnCorrectElement(int index, int numberToInsert, params int[] numbers)
        {
            //Arrange
            BadList badList = new BadList();
            foreach (var item in numbers)
            {
                badList.Add(item);
            }
            //Act
            badList.InsertAt(index, numberToInsert);

            //Assert
            Assert.AreEqual(numberToInsert, badList.Get(index));

        }
    }
}