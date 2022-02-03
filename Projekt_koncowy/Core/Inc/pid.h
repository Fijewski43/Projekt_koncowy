/*
 * pid.h
 *
 *  Created on: 3 lut 2022
 *      Author: fijew
 */

#ifndef INC_PID_H_
#define INC_PID_H_



#endif /* INC_PID_H_ */

typedef struct {
	float Kp;
	float Ki;
	float Kd;
	float dt;
} pid_parametrs_t;

typedef struct {
	pid_parametrs_t p;
	float previous_error, previous_integral;
} pid;


float calculate_discrete_pid(pid *pid, float setpoint, float measured);
