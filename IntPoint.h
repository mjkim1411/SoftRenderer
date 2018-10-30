#pragma once
#include "Vector.h"

struct IntPoint
{
public:
	int X;
	int Y;

public:
	IntPoint() : X(0), Y(0) {}
	IntPoint(int InX, int InY) : X(InX), Y(InY) {}
	IntPoint(Vector2 InVector2) : X((int)InVector2.X), Y((int)InVector2.Y) {}

	Vector2 ToVector2() { return Vector2((float)X, (float)Y); }
};