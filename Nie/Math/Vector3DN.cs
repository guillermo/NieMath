

namespace Nie.Math
{
    /// <summary>
    /// Statically normalized 3D vector. Always have a length of 1.
    /// </summary>
    public struct Vector3DN : IVector3D<float>
    {
        #region Conversion
        public static implicit operator Vector3D(Vector3DN a)
        {
            return a.mBase;
        }
        public static explicit operator Vector3DN(Vector3D a)
        {
            Debug.Assert(a.IsNormal());
            Vector3DN v;
            v.mBase = a;
            return v;
        }
        #endregion

        #region IVector3D
        public float x { get { return mBase.x; } set { mBase.x = value; } }
        public float y { get { return mBase.y; } set { mBase.y = value; } }
        public float z { get { return mBase.z; } set { mBase.z = value; } }
        #endregion
        
        public Vector2D xy { get { return mBase.xy; } set { mBase.xy = value;} }
        public Vector2D yz { get { return mBase.yz; } set { mBase.yz = value;} }
        public Vector2D xz { get { return mBase.xz; } set { mBase.xz = value;} }

        public Vector2D xx { get { return mBase.xx; } }
        public Vector2D yy { get { return mBase.yy; } }
        public Vector2D zz { get { return mBase.zz; } }
        public Vector3D xxx { get { return mBase.xxx; } }
        public Vector3D yyy { get { return mBase.yyy; } }
        public Vector3D zzz { get { return mBase.zzz; } }

        #region Constructor
        public Vector3DN(float x, float y, float z)
        {
            mBase = new Vector3D(x,y,z);
            Debug.Assert(mBase.IsNormal());
        }
        public Vector3DN(Vector3D a)
        {
            mBase = a;
            Debug.Assert(mBase.IsNormal());
        }
        #endregion

        #region Object
        public override bool Equals(object other) { return mBase.Equals(other); }
        public override int GetHashCode() { return mBase.GetHashCode(); }
        public override string ToString() { return mBase.ToString(); }
        #endregion


        public Vector3DN normalized { get { return this; } }
        public float length { get { return 1; } }
        public float sqrLength { get { return 1; } }
        public bool IsNormal() { return true; }



        public float Dot(Vector3D a) { return mBase.Dot(a); }
        public Vector3D Cross(Vector3D a) { return mBase.Cross(a); }


        #region Operator
        public static Bool3 operator < (Vector3DN a, Vector3DN b) { return new Bool3(a.x < b.x, a.y < b.y, a.z < b.z); }
        public static Bool3 operator > (Vector3DN a, Vector3DN b) { return new Bool3(a.x > b.x, a.y > b.y, a.z > b.z); }
        public static Bool3 operator <=(Vector3DN a, Vector3DN b) { return new Bool3(a.x <= b.x, a.y <= b.y, a.z <= b.z); }
        public static Bool3 operator >=(Vector3DN a, Vector3DN b) { return new Bool3(a.x >= b.x, a.y >= b.y, a.z >= b.z); }
        public static Bool3 operator !=(Vector3DN a, Vector3DN b) { return new Bool3(a.x != b.x, a.y != b.y, a.z != b.z); }
        public static Bool3 operator ==(Vector3DN a, Vector3DN b) { return new Bool3(a.x == b.x, a.y == b.y, a.z == b.z); }

        public static Vector3D operator +(Vector3DN a, Vector3DN b) { return new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z); }
        public static Vector3D operator -(Vector3DN a, Vector3DN b) { return new Vector3D(a.x - b.x, a.y - b.y, a.z - b.z); }
        public static Vector3D operator *(Vector3DN a, Vector3DN b) { return new Vector3D(a.x * b.x, a.y * b.y, a.z * b.z); }
        public static Vector3D operator /(Vector3DN a, Vector3DN b) { return new Vector3D(a.x / b.x, a.y / b.y, a.z / b.z); }
        public static Vector3D operator *(Vector3DN a, float b) { return new Vector3D(a.x * b, a.y * b, a.z * b); }
        public static Vector3D operator /(Vector3DN a, float b) { return new Vector3D(a.x / b, a.y / b, a.z / b); }
        public static Vector3D operator *(float a, Vector3DN b) { return new Vector3D(a * b.x, a * b.y, a * b.z); }
        public static Vector3D operator /(float a, Vector3DN b) { return new Vector3D(a / b.x, a / b.y, a / b.z); }

        public static Vector3DN operator -(Vector3DN a) { return new Vector3DN(-a.x, -a.y, -a.z); }
        #endregion

        #region Angle
        public bool IsWithin90DegreeOf(Vector3D a) { return mBase.IsWithin90DegreeOf(a); }
        public bool IsPerpendicular(Vector3D a) { return mBase.IsPerpendicular(a); }
        public bool IsPerpendicularNear(Vector3D a) { return mBase.IsPerpendicularNear(a); }
        public bool IsParallel(Vector3D a) { return mBase.IsParallel(a); }
        public bool IsParallelNear(Vector3D a) { return mBase.IsParallelNear(a); }
        public AngleCos AngleBetween(Vector3D a) { return new AngleCos(Dot(a.normalized)); }
        public AngleCos AngleBetween(Vector3DN a) { return new AngleCos(Dot(a)); }
        #endregion

        Vector3D mBase;
    }
}