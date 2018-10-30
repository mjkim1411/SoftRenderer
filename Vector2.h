#pragma once
#include "stdafx.h"
#include "Matrix.h"

struct Vector2
{
public:
	float X;
	float Y;

public:
	Vector2() : X(0), Y(0) {}
	Vector2(float InX, float InY) : X(InX), Y(InY) {}

	static float Dist(const Vector2 &V1, const Vector2 &V2);
	static float DistSquared(const Vector2 &V1, const Vector2 &V2);

	Vector2 operator*(const Matrix2 &Mat) const;

	bool Equals(const Vector2& V, float tolerance = KINDA_SMALL_NUMBER) const;
};