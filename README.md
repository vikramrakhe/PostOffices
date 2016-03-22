# PostOffices

##Introduction

This is an exercise in managing a tree data structure, using C#. 
Your job is to write a function SuggestCompletedNames that takes the start of a name of Post Office in India and returns all the possible ways the string could be completed to form a valid Post Office name.

```
IEnumerable<string> SuggestCompletedNames(string startOfName)
```

For example, given the input ```"Abusa"```, the function returns ```{ "idpur B.O ", "ar B.O" }```, representing Abusaidpur B.O and Abusar B.O. But given the input ```"Abuso"``` the function returns an empty IEnumerable, as there are no Post Offices starting with the given string.
In fact, you’re going to write two implementations. The first is going to use Linq to find the answer by searching through the list of names. You will find the implementation quite straightforward. 
In the second, you’re going to implement a solution by building a tree-based dictionary. The tree is constructed such that each node represents a character in the alphabet, and each word in the dictionary is stored as a traversal from the root node (which represents the start of a word) to a leaf node (or some other node that represents the end of a word).
For example, the word “and” is represented by the traversal root -> A -> N -> D, while “any” would be root -> A -> N -> Y. So a dictionary that had both “and” and “any” would have the tree 

```
root -> A ->N -> D
              -> Y
```

##Instructions

Check out the branch StartHere (don’t check out master!). This gives you a good starting point consisting of a class, PostOfficeDataFile, that reads a list of Indian Post Offices and provides the Post Office names an IEnumerable of strings.

### SimplePostOfficeNameCompleter
Here you’re going to develop a simple Post Office name completer that searches for possible matching names in the list of Post Office strings. You should use linq in your implementation.
Here are the acceptance criteria for the behaviour: 
a.	Given an empty string, the method should return an empty IEnumerable
b.	Given a string that matches a number of Post Office names, the method should return the complete set of possible completion strings
c.	Given a string that doesn’t match any Post Office name, the method should return an empty IEnumerable
d.	Given duplicate Post Office names in the file, the method should not return duplicate values
If you want to give TDD a go, that would be great, but this isn’t a TDD exercise so don’t focus on TDD to the expense of writing good, testable, C#. But do write some tests and give a lot of thought to the best way to test your class.

###TreeBasedPostOfficeNameCompleter

Here you’re going to develop the tree-based name completer. At the heart will be a tree-based dictionary.

#### 1. DictionaryNode
Start by implementing a DictionaryNode. DictionaryNode has the following public methods

```public DictionaryNode FindNodeOrNull(char c)``` 

FindNodeOrNull(char c) returns the child node representing the char c. If the node doesn’t exist it returns null.

```public DictionaryNode FindNodeOrAdd(char c)``` 

FindNodeOrAdd(char c) returns the child node representing the char c. If the node doesn’t exist, it also adds it as a child node.

```IEnumerable<string> Words(string startOfWord)```

Words returns the set of words formed by traversing from the node to all the nodes that represent ends of words, and by appending them to startOfWord. For example, given the tree 

```
root -> A ->N -> D
              -> Y
```

Calling Words(“A”) on the Node representing N, would yield { “AND”, ANY”}

#### 2. TreeBasedDictionary
Next, using TDD, implement a TreeBasedDictionary class that has the following public methods

```DictionaryNode Find(string startOfWord)``` 

Returns the DictionaryNode that represents startOfWord in the dictionary. 

```void Add(string word)``` 

Adds the word to the dictionary (by writing DictionaryNodes)

```Words(string startOfWord)```

Returns all the strings that complete names in the dictionary that with startOfWord

#### 3.	Now implement a TreeBasedPostOfficeNameCompleter. 
This is just the same as the SimplePostOfficeNameCompleter (you can reuse the tests!) except that it is implemented in terms of the TreeBasedDictionary.

#### 4.	Performance?
Finally, as a bit of fun, write a test ```GivenTreeBasedAndSimpleCompleters_WhenLookupCalled_TreeBasedShouldBeFaster``` that proves the tree-based look up is faster (ignore the time taken to read in the data and initialise the structure). How much faster is it?

