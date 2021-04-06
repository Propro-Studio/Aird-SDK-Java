
inline void acc(__global const float* mzArray,__global const float* intArray,int id, int mzLength, float targetStart, float targetEnd,__global float* results)
{
     int high = mzLength - 1;
        int index = 0;
        if(targetStart <= mzArray[0]){
            index=0;
        }else if(targetStart >= mzArray[high]){
            index=-1;
        }else{
            int low = 0;
            while (low + 1 < high) {
                int mid = (low + high)/2;
                if (targetStart < mzArray[mid]) {
                    high = mid;
                } else if (targetStart > mzArray[mid]) {
                    low = mid;
                } else {
                    high=mid;
                    break;
                }
            }
            index=high;
        }
        if(index == -1){
            results[id] = 0;
        }else{
            float intensitySum = 0;
            while(index < mzLength && mzArray[index] <= targetEnd){
                intensitySum += intArray[index];
                index++;
            }
            results[id] = intensitySum;
        }
}

__kernel void lowerBound(__global const float* targets,
                  const int targetLength,
                  __global const float* mzArray1,
                  __global const float* intArray1,
                  const int length1,
                  __global const float* mzArray2,
                  __global const float* intArray2,
                  const int length2,
                  __global const float* mzArray3,
                  __global const float* intArray3,
                  const int length3,
                  __global const float* mzArray4,
                  __global const float* intArray4,
                  const int length4,
                  __global const float* mzArray5,
                  __global const float* intArray5,
                  const int length5,
                  const float mzWindow,
                  __global float* results){
    int id = get_global_id(0);
    float targetStart = targets[id] - mzWindow/2;
    float targetEnd = targets[id] + mzWindow/2;
    if(length1 != 0){
        acc(mzArray1, intArray1, id+targetLength*0, length1, targetStart, targetEnd, results);
    }
    if(length2 != 0){
        acc(mzArray2, intArray2, id+targetLength*1, length2, targetStart, targetEnd, results);
    }
    if(length3 != 0){
        acc(mzArray3, intArray3, id+targetLength*2, length3, targetStart, targetEnd, results);
    }
    if(length4 != 0){
        acc(mzArray4, intArray4, id+targetLength*3, length4, targetStart, targetEnd, results);
    }
    if(length5 != 0){
        acc(mzArray5, intArray5, id+targetLength*4, length5, targetStart, targetEnd, results);
    }
    return;
}
