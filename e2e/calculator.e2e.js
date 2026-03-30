import { Selector } from 'testcafe';

fixture('Calculator frontend E2E')
    .page(process.env.BASE_URL);

test('user can add two numbers and see the result', async t => {
    const inputA = Selector('#a');
    const inputB = Selector('#b');
    const operation = Selector('#operation');
    const calculatorType = Selector('#calculatorType');
    const result = Selector('#result');
    const calculateButton = Selector('button').withText('Calculate');

    await t
        .typeText(inputA, '5', { replace: true })
        .typeText(inputB, '3', { replace: true })
        .click(operation)
        .click(operation.find('option').withAttribute('value', 'add'))
        .click(calculatorType)
        .click(calculatorType.find('option').withAttribute('value', 'simple'))
        .click(calculateButton)
        .expect(result.innerText).contains('8');
});