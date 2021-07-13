# Rolling-Sphere

using System;
using System.Collections;
using System.Collections.Generic;
public class Node<ObjectType>
{
	ObjectType data;
	Node<ObjectType> next;
	public Node(ObjectType obj)
	{
		data = obj;
	}
}
public class LinkedList<ObjectType>
{
	Node<ObjectType> begin;
	Node<ObjectType> end;
	private int _size;
	public int size { get {return _size };private set {_size = value }; }

	public void Add(ObjectType obj)
	{
		Node<ObjectType> node = new Node<ObjectType>(obj);

		if (begin == null)
		{
			begin = node;
		}
		else
		{
			end.next = node;
		}
			
		end = node;
		size++;
	}

	public void PopFront()
    {
		if (size > 0)
		{
			begin = begin.next;
			size--;
		}
    }

	public void ShowAllElements()
    {
		var current = begin;
        while (current != null)
        {
			Console.WriteLine(current.data);
			current = begin.next;
        }
    }
}
