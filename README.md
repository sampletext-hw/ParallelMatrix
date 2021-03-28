# Parallel Matrix

## Application performs multithreaded matrix multiplication 
### with different matrix sizes and threads amount

### Written in C#

## Results

Everything is performed on 

Intel Core I5 10210U (4 cores / 8 threads up to 4.1 GHz)

- Size 100
    * Measuring SingleThread Size of {100}
      
        Operation elapsed in: 36 ms
    * Measuring MultiThread Size of {100} and degree {4}
      
        Operation elapsed in: 28 ms
    * Measuring MultiThread Size of {100} and degree {8}
      
        Operation elapsed in: 29 ms
    * Measuring MultiThread Size of {100} and degree {16}
      
        Operation elapsed in: 31 ms
  
- Size 500
    * Measuring SingleThread Size of {500}
      
        Operation elapsed in: 3080 ms
    * Measuring MultiThread Size of {500} and degree {4}
      
        Operation elapsed in: 2334 ms
    * Measuring MultiThread Size of {500} and degree {8}
      
        Operation elapsed in: 1715 ms
    * Measuring MultiThread Size of {500} and degree {16}
      
        Operation elapsed in: 1699 ms
      
- Size 1000
    * Measuring SingleThread Size of {1000}
      
        Operation elapsed in: 25156 ms
    * Measuring MultiThread Size of {1000} and degree {4}
      
        Operation elapsed in: 17487 ms
    * Measuring MultiThread Size of {1000} and degree {8}
      
        Operation elapsed in: 14602 ms
    * Measuring MultiThread Size of {1000} and degree {16}
      
        Operation elapsed in: 14207 ms
