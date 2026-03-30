import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    vus: 50,
    duration: '10s',
};

export default function () {
    const baseUrl = __ENV.BASE_URL;

    http.post(`${baseUrl}/api/calculations`, JSON.stringify({
        a: 1,
        b: 2,
        operation: 'add',
        calculatorType: 'simple'
    }), {
        headers: { 'Content-Type': 'application/json' },
    });

    sleep(1);
}