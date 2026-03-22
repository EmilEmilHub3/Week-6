import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '5s', target: 5 },
        { duration: '10s', target: 30 },
        { duration: '5s', target: 0 },
    ],
};

export default function () {
    const payload = JSON.stringify({
        a: 10,
        b: 5,
        operation: 'add',
        calculatorType: 'simple'
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.post('http://127.0.0.1:8080/api/calculations', payload, params);

    check(res, {
        'status is 200': (r) => r.status === 200,
    });

    sleep(1);
}