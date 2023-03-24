using System;

class Node
{
    private int x;
    private int y;
    private char nodeType;
    private bool marked;
    private Node prevNode;

    public Node(int x, int y, char nodeType)
    {
        this.x = x;
        this.y = y;
        this.nodeType = nodeType;
        this.marked = false;
        this.prevNode = null;
    }

    public int getX() { return this.x;}
    public int getY() { return this.y;}
    public char getNodeType() { return this.nodeType;}
    public bool getMarked() { return this.marked;}
    public void setMarked(bool marked) { this.marked = marked;}
    public Node getPrevNode() { return this.prevNode;}
    public void setPrevNode(Node prevNode) { this.prevNode = prevNode; }
}
