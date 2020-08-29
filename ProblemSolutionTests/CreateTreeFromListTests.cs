using System.Collections.Generic;
using System.Linq;
using ProblemSolution;
using Xunit;

namespace ProblemSolutionTests
{
    public class CreateTreeFromListTests
    {
        private readonly List<Node> _flatDataStructure;
        private readonly Node _node1;
        private readonly Node _node2;
        private readonly Node _node3;
        private readonly Node _node4;
        private readonly Node _node5;
        private readonly Node _node6;
        private readonly Node _node8;

        public CreateTreeFromListTests()
        {
            _node1 = new Node
            {
                Id = 1
            };

            _node2 = new Node
            {
                Id = 2
            };

            _node3 = new Node
            {
                Id = 3,
                ParentId = 2
            };

            _node4 = new Node
            {
                Id = 4,
                ParentId = 1
            };

            _node5 = new Node
            {
                Id = 5,
                ParentId = 3
            };

            _node6 = new Node
            {
                Id = 6,
                ParentId = 4
            };

            _node8 = new Node
            {
                Id = 8,
                ParentId = 4
            };


            _flatDataStructure = new List<Node>
            {
                _node8, _node1, _node3, _node6, _node4, _node5, _node2
            };
        }

        [Fact]
        public void TestExecuteShouldCreateRootOfTree()
        {
            //Arrange
            var expectedResult = new List<Node> {_node1, _node2};

            //Act
            var result = CreateTreeFromList.Execute(_flatDataStructure);

            //Assert
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void TestExecuteShouldCreateCorrectGraph()
        {
            //Arrange
            //Creating the following graph
            //root     1      2  
            //         |      | 
            //         4      3 
            //        / \     |
            //       6   8    5

            var expectedResult = new List<Node>
            {
                new Node
                {
                    Id = 1, //Node 1
                    ParentId = null,
                    Children = new List<Node>
                    {
                        new Node //Node 4
                        {
                            Id = 4,
                            ParentId = 1,
                            Children = new List<Node>
                            {
                                new Node {Id = 8, ParentId = 4}, //Node 8
                                new Node {Id = 6, ParentId = 4} //Node 6
                            }
                        }
                    }
                },
                new Node //Node 2
                {
                    Id = 2,
                    ParentId = null,
                    Children = new List<Node>
                    {
                        new Node
                        {
                            Id = 3,
                            ParentId = 2,
                            Children = new List<Node>
                            {
                                new Node {Id = 5, ParentId = 3} //Node 5
                            }
                        }
                    }
                }
            };


            //Act
            var result = CreateTreeFromList.Execute(_flatDataStructure);

            //Assert

            Assert.Equal(expectedResult.Count, result.Count);

            //Node 1
            Assert.Equal(expectedResult[0], result[0]);

            //Node 2
            Assert.Equal(expectedResult[1], result[1]);

            //Node 4  
            Assert.Equal(expectedResult[0].Children.ToList()[0], result[0].Children.ToList()[0]);

            //Node 6
            var expectedNode6 = expectedResult[0]
                .Children
                .ToList()[0]
                .Children
                .ToList()[0];

            var resultNode6 = result[0]
                .Children
                .ToList()[0]
                .Children
                .ToList()[0];

            Assert.Equal(expectedNode6, resultNode6);


            //Node 8
            var expectedNode8 = expectedResult[0]
                .Children
                .ToList()[0]
                .Children
                .ToList()[1];

            var resultNode8 = result[0]
                .Children
                .ToList()[0]
                .Children
                .ToList()[1];

            Assert.Equal(expectedNode8, resultNode8);

            //Node 3
            Assert.Equal(expectedResult[1].Children.ToList()[0], result[1].Children.ToList()[0]);


            //Node 5
            var expectedNode5 = expectedResult[1]
                .Children
                .ToList()[0]
                .Children
                .ToList()[0];

            var resultNode5 = result[1]
                .Children
                .ToList()[0]
                .Children
                .ToList()[0];


            Assert.Equal(expectedNode5, resultNode5);
        }

        [Fact]
        public void TestCompareShouldCompareTwoNodes()
        {
            //Arrange
            var node1 = new Node
            {
                Id = 6,
                ParentId = 4,
                Children = new List<Node>
                {
                    new Node {Id = 5, ParentId = 3}
                }
            };

            var node2 = new Node
            {
                Id = 6,
                ParentId = 4,
                Children = new List<Node>
                {
                    new Node {Id = 5, ParentId = 3}
                }
            };
            //Act
            //Assert
            Assert.Equal(node1, node2);
        }
    }
}