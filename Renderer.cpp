#include "stdafx.h"
#include "SoftRenderer.h"
#include "GDIHelper.h"
#include "Renderer.h"

#include "Vector.h"
#include "IntPoint.h"

bool IsInRange(int x, int y);
void PutPixel(int x, int y);

bool IsInRange(int x, int y)
{
	return (abs(x) < (g_nClientWidth / 2)) && (abs(y) < (g_nClientHeight / 2));
}

void PutPixel(const IntPoint& InPt)
{
	PutPixel(InPt.X, InPt.Y);
}

void PutPixel(int x, int y)
{
	if (!IsInRange(x, y)) return;

	ULONG* dest = (ULONG*)g_pBits;
	DWORD offset = g_nClientWidth * g_nClientHeight / 2 + g_nClientWidth / 2 + x + g_nClientWidth * -y;
	*(dest + offset) = g_CurrentColor;
}


void UpdateFrame(void)
{
	// Buffer Clear
	SetColor(32, 128, 255);
	Clear();

	float Cradius = 10.0f;
	int Cnradius = (int)Cradius;
	Vector3 center(0.0f, 0.0f);

	// Circle
	static float Cdegree = 0;
	Cdegree += -1;
	Cdegree = fmodf(Cdegree, 30.0f);

	Matrix3 circleMoveMatrix;
	circleMoveMatrix.SetTranslation(0.f, 0.f);

	float CmaxPos = 1;
	float Cpos = sinf(Deg2Rad(Cdegree)) * CmaxPos;
	Matrix3 circleRotationMatrix;
	circleRotationMatrix.SetTranslation(Cpos, Cpos);

	Matrix3 circleMatrix = circleRotationMatrix * circleMoveMatrix;

	// Circle Color
	static Vector3 Ccolor;
	Ccolor.X += 1;
	Ccolor.Y += 0.5f;
	Ccolor.Z += 1;

	Ccolor.X = fmodf(Ccolor.X, 155.0f);
	Ccolor.Y = fmodf(Ccolor.Y, 255.0f);
	Ccolor.Z = fmodf(Ccolor.Z, 105.0f);

	SetColor(Ccolor.X, Ccolor.Y, Ccolor.Z);

	// Circle Draw
	for (int i = -Cnradius; i <= Cnradius; i++)
	{
		for (int j = -Cnradius; j <= Cnradius; j++)
		{
			Vector3 vertex(i, j);
			if (Vector3::Dist(center, vertex) <= Cradius)
				PutPixel(Vector3(i, j) * circleMatrix);
		}
	}


	// Draw
	static Vector3 cor;
	cor.X += 0.1f;
	cor.Y += 0.2f;
	cor.Z += 0.1f;

	cor.X = fmodf(cor.X, 255.0f);
	cor.Y = fmodf(cor.Y, 130.0f);
	cor.Z = fmodf(cor.Z, 100.0f);

	SetColor(cor.X, cor.Y, cor.Z);

	// Draw a filled circle with radius 100
	float radius = 30.0f;
	int nradius = (int)radius;

	static float degree = 0;
	degree += -1;
	degree = fmodf(degree, 360.0f);

	Matrix3 rotMat;
	rotMat.SetRotation(degree);
	rotMat.Transpose();

	float maxScale = 1;
	float scale = ((sinf(Deg2Rad(degree * 2)) + 1) * 0.5) * maxScale;
	if (scale < 0.5f) scale = 0.5f;

	Matrix3 scaleMat;
	scaleMat.SetScale(scale, scale, scale);

	float maxPos = 110;
	float pos = sinf(Deg2Rad(degree)) * maxPos;
	Matrix3 translationMat;
	translationMat.SetTranslation(-pos, pos);

	Matrix3 SR = scaleMat * rotMat;
	Matrix3 TRS = translationMat * rotMat * scaleMat;

	for (int i = -nradius; i <= nradius; i++)
	{
		for (int j = -nradius; j <= nradius; j++)
		{
			PutPixel(Vector3((float)i, (float)j) * TRS);
		}
	}

	// Buffer Swap 
	BufferSwap();
}
