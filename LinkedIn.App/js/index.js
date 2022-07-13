//@ts-check

let params = new URL(document.location.toString()).searchParams;

const code = params.get('code');

if (code === null) {
  console.log('New user!');
} else {
  console.log(code);
}

const baseUrl = 'https://localhost:7256/';
const apiRoute = baseUrl + 'api/Auth/token?';
const codeParams = new URLSearchParams();
codeParams.append('code', code);

fetch(apiRoute + codeParams)
  .then((response) => response.json())
  .then((response) => console.log(response));
